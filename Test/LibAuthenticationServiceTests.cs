using LibruaryAPI.Application.Interfaces;
using LibruaryAPI.Application.Services;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Infrastructure.JwtSet;
using LibruaryAPI.Infrastructure.RefreshTokenSet.Options;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class LibAuthenticationServiceTests
{
    private readonly Mock<IBaseRepository<AppUsers>> _mockRepo;
    private readonly Mock<IJwtGenerator> _mockJwtGenerator;
    private readonly MutableDbContext _context;
    private readonly LibAuthenticationService _authService;

    public LibAuthenticationServiceTests()
    {
        _mockRepo = new Mock<IBaseRepository<AppUsers>>();
        _mockJwtGenerator = new Mock<IJwtGenerator>();
        _context = MocDbContextMockDbContext.CreateDbContext();
        _authService = new LibAuthenticationService(_mockRepo.Object, _mockJwtGenerator.Object, _context);
    }

    [Fact]
    public async Task RegisterAsync_ShouldRegisterUser_WhenValidData()
    {
        // Arrange
        var name = "Test User";
        var email = "testuser@example.com";
        var password = "Password123";

        _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<AppUsers>(), It.IsAny<CancellationToken>()))
                 .Returns(Task.CompletedTask);

        // Act
        var result = await _authService.RegisterAsync(name, email, password, CancellationToken.None);

        // Assert
        Assert.Equals("Registration complete", result);
    }

    [Fact]
    public async Task RegisterAsync_ShouldThrowException_WhenEmailExists()
    {
        // Arrange
        var name = "Test User";
        var email = "testuser@example.com";
        var password = "Password123";

        _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<AppUsers>(), It.IsAny<CancellationToken>()))
                 .Throws(new KeyNotFoundException("Email already exists"));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
            _authService.RegisterAsync(name, email, password, CancellationToken.None));
    }

    [Fact]
    public async Task SignInAsync_ShouldReturnToken_WhenValidCredentials()
    {
        // Arrange
        var email = "testuser@example.com";
        var password = "Password123";
        var user = new AppUsers
        {
            UserEmail = email,
            Password = password,
            Name = "Test User"
        };
        _context.Add(user);
        await _context.SaveChangesAsync();

        _mockJwtGenerator.Setup(jwt => jwt.GenerateToken(It.IsAny<AppUsers>(), It.IsAny<IList<string>>()))
                         .Returns("valid_token");

        // Act
        var result = await _authService.SignInAsync(email, password, CancellationToken.None);

        // Assert
        Assert.Equals("valid_token", result);
    }

    [Fact]
    public async Task SignInAsync_ShouldThrowUnauthorizedException_WhenInvalidCredentials()
    {
        // Arrange
        var email = "wrongemail@example.com";
        var password = "WrongPassword";

        // Act & Assert
        await Assert.ThrowsExceptionAsync<UnauthorizedAccessException>(() =>
            _authService.SignInAsync(email, password, CancellationToken.None));
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldResetPassword_WhenValidData()
    {
        // Arrange
        var email = "testuser@example.com";
        var newPassword = "NewPassword123";
        var user = new AppUsers
        {
            Name = "name",
            UserEmail = email,
            Password = "OldPassword123"
        };
        _context.Add(user);
        await _context.SaveChangesAsync();

        // Act
        var result = await _authService.ResetPasswordAsync(email, newPassword, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(newPassword == user.Password);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldThrowException_WhenUserNotFound()
    {
        // Arrange
        var email = "nonexistentuser@example.com";
        var newPassword = "NewPassword123";

        // Act & Assert
        await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() =>
            _authService.ResetPasswordAsync(email, newPassword, CancellationToken.None));
    }

    [Fact]
    public async Task SignOutAsync_ShouldRevokeTokens_WhenValidToken()
    {
        // Arrange
        var token = "valid_token";
        var userId = 1;
        var refreshToken = new RefreshTokenOptions
        {
            UserId = userId,
            RefreshToken = "valid_token",
            IsRevoked = false
        };

        _context.Add(refreshToken);
        await _context.SaveChangesAsync();

        // Act
        await _authService.SignOutAsync(token, CancellationToken.None);

        // Assert
        var updatedToken = await _context.Set<RefreshTokenOptions>()
                                          .FirstOrDefaultAsync(x => x.RefreshToken == token);
        Assert.IsTrue(updatedToken.IsRevoked);
    }
}
