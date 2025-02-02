namespace HRAS_2023.Context;

using Microsoft.EntityFrameworkCore;
using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public class HrasDbContext : DbContext
{
    public HrasDbContext(DbContextOptions<HrasDbContext> options) : base(options)
    {
    }

    public DbSet<Diagnoses> Diagnoses { get; set; } = null!;

    public DbSet<Home> Home { get; set; } = null!;

    public DbSet<Inventory> Inventory { get; set; } = null!;

    public DbSet<Modifies> Modifies { get; set; } = null!;

    public DbSet<Patient> Patient { get; set; } = null!;

    public DbSet<Room> Room { get; set; } = null!;

    public DbSet<StaysIn> StaysIn { get; set; } = null!;

    public DbSet<Symptom> Symptom { get; set; } = null!;

    public DbSet<VisitHistory> VisitHistory { get; set; } = null!;

    public DbSet<SearchViewModel> SearchViewModel { get; set; } = null!;

	public DbSet<InventoryViewModel> InventoryViewModel { get; set; } = null!;
}