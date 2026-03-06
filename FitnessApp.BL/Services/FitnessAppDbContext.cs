using FitnessApp.BL.Models;
using System.Data.Entity;

namespace FitnessApp.BL.Services
{
    internal class FitnessAppDbContext : DbContext
    {
        public FitnessAppDbContext() : base("FitnessAppConnection") { }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
