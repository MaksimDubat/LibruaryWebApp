﻿using LibruaryAPI.Application.JwtSet.Options;
using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Infrastructure.DataBase
{
    /// <summary>
    /// Контекст БД для управления сущностями.
    /// </summary>
    public class MutableDbContext : DbContext
    {
        public MutableDbContext(DbContextOptions<MutableDbContext> options) : base(options) { }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppRoles> AppRoles { get; set; }
        public DbSet<AppUsersRoles> AppUsersRoles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Cart> Cart {  get; set; }
        public DbSet<RefreshTokenOptions> RefreshTokenOptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MutableDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public bool HasPeddingChanges()
        {
            return ChangeTracker.HasChanges();
        }


    }
}
