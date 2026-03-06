namespace FitnessApp.BL.Migrations
{
    using FitnessApp.BL.Services;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // На проде так НЕ ДЕЛАТЬ
            ContextKey = "FitnessApp.BL.Services.FitnessAppDbContext";
        }

        protected override void Seed(FitnessAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
