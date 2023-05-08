namespace HRAS_2023.Context;

using Microsoft.EntityFrameworkCore;
using HRAS_2023.Models;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<Staff> Staff { get; set; } = null!;
}