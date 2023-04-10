namespace HRAS.Context;

using Microsoft.EntityFrameworkCore;
using HRAS.Models;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<HRAS.Models.Staff> Staff { get; set; } = null!;
}