using HRAS.Models;
using HRAS_2023.Models;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace HRAS_2023.Data
{
    public class HRAS_2023Context : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

    }
}
