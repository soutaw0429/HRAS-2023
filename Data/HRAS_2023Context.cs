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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            //I will change this, hardcoding this string is a bad practice!
            //desktop-rmqlafu\sqlexpress.TestDB.dbo
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HRAS_2023_InitialCreate; Integrated Security=True;");
        }
    }
}
