namespace DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DAL.Configuration;

    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
            : base("name=TravelAgencyContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TravelAgencyContext>());
        }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FutureTour> FutureTours { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<LoginData> LoginDatas { get; set; }
        public virtual DbSet<PastTour> PastTours { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<PotentionalTourist> PotentionalTourists { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Hotels)
                .WithOptional(e => e.City)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.Country)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoginData>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.LoginData)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserRole)
                .WillCascadeOnDelete();

            modelBuilder.Configurations.Add(new AttractionConfiguration());
            modelBuilder.Configurations.Add(new PictureConfiguration());
            modelBuilder.Configurations.Add(new TourConfiguration());
        }
    }
}