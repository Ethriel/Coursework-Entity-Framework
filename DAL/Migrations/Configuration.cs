using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Model.TravelAgencyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Model.TravelAgencyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
