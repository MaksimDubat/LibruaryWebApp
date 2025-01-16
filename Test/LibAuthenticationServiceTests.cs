using LibruaryAPI.Application.Services;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Infrastructure.JwtSet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

[TestFixture]
public class LibAuthenticationServiceTests
{
    private Mock<IBaseRepository<AppUsers>> _mockRepo;
    private Mock<IJwtGenerator> _mockJwtGenerator;
    private Mock<IPasswordHasher<AppUsers>> _mockPasswordHasher;
    private DbContextOptions<MutableDbContext> _dbContextOptions;
    private MutableDbContext _context;
    private LibAuthenticationService _authService;

    [SetUp]
    public void SetUp()
    {
        _mockRepo = new Mock<IBaseRepository<AppUsers>>();
        _mockJwtGenerator = new Mock<IJwtGenerator>();
        _mockPasswordHasher = new Mock<IPasswordHasher<AppUsers>>();

        _dbContextOptions = new DbContextOptionsBuilder<MutableDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new MutableDbContext(_dbContextOptions);
        _authService = new LibAuthenticationService(
            _mockRepo.Object,
            _mockJwtGenerator.Object,
            _mockPasswordHasher.Object,
            _context,
            null,
            null
        );
    }

    [Test]
    public async Task RegisterAsync_ShouldRegisterUser_WhenValidData()
    {
        var name = "Test User";
        var email = "testuser@example.com";
        var password = "Password123";

        _mockPasswordHasher
            .Setup(ph => ph.HashPassword(It.IsAny<AppUsers>(), password))
            .Returns("hashed_password");

        _mockRepo
            .Setup(repo => repo.AddAsync(It.IsAny<AppUsers>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var result = await _authService.RegisterAsync(name, email, password, CancellationToken.None);

        NUnit.Framework.Assert.That(result.Succeeded, Is.True);
    }

    [Test]
    public async Task RegisterAsync_ShouldReturnFailedResult_WhenEmailExists()
    {
        var name = "Test User";
        var email = "testuser@example.com";
        var password = "Password123";

        _context.Add(new AppUsers { Name = name, UserEmail = email, Password = "hashed_password" });
        await _context.SaveChangesAsync();

        var result = await _authService.RegisterAsync(name, email, password, CancellationToken.None);

        NUnit.Framework.Assert.That(result.Succeeded, Is.False);
        NUnit.Framework.Assert.That(result.Errors.Select(e => e.Description), Does.Contain("Email already exists"));
    }

    [Test]
    public async Task SignInAsync_ShouldReturnToken_WhenValidCredentials()
    {
        var email = "testuser@example.com";
        var password = "Password123";

        var user = new AppUsers { Name = "Test User", UserEmail = email, Password = "hashed_password" };
        _context.Add(user);
        await _context.SaveChangesAsync();

        _mockPasswordHasher
            .Setup(ph => ph.VerifyHashedPassword(user, "hashed_password", password))
            .Returns(PasswordVerificationResult.Success);

        _mockJwtGenerator
            .Setup(jwt => jwt.GenerateToken(It.IsAny<AppUsers>(), It.IsAny<IList<string>>()))
            .Returns("valid_token");

        var result = await _authService.SignInAsync(email, password, CancellationToken.None);

        NUnit.Framework.Assert.That(result, Is.EqualTo("valid_token"));
    }

    [Test]
    public async Task SignInAsync_ShouldThrowUnauthorizedException_WhenInvalidCredentials()
    {
        var email = "testuser@example.com";
        var password = "WrongPassword";

        var user = new AppUsers { Name = "Test User", UserEmail = email, Password = "hashed_password" };
        _context.Add(user);
        await _context.SaveChangesAsync();

        _mockPasswordHasher
            .Setup(ph => ph.VerifyHashedPassword(user, "hashed_password", password))
            .Returns(PasswordVerificationResult.Failed);

        var ex = NUnit.Framework.Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _authService.SignInAsync(email, password, CancellationToken.None));

        NUnit.Framework.Assert.That(ex.Message, Is.EqualTo("Invalid email or password"));
    }

    [Test]
    public async Task ResetPasswordAsync_ShouldResetPassword_WhenValidData()
    {
        // Arrange
        var email = "testuser@example.com";
        var token = "validResetToken"; // Токен сброса пароля
        var newPassword = "NewPassword123";

        var user = new AppUsers
        {
            Name = "Test User",
            UserEmail = email,
            Password = "OldPassword123"
        };

        _context.Add(user);
        await _context.SaveChangesAsync();

        _mockPasswordHasher
            .Setup(ph => ph.HashPassword(user, newPassword))
            .Returns("hashed_new_password");

        // Act
        var result = await _authService.ResetPasswordAsync(email, token, newPassword, CancellationToken.None);

        // Assert
        NUnit.Framework.Assert.That(result, Is.True);
        NUnit.Framework.Assert.That(user.Password, Is.EqualTo("hashed_new_password"));
    }

}
