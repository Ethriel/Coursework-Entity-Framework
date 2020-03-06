namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attraction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttractionName = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false, maxLength: 50),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 20),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourName = c.String(nullable: false, maxLength: 60),
                        Price = c.Decimal(storeType: "money"),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        MaxTourists = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 30),
                        EmploymentDate = c.DateTime(nullable: false, storeType: "date"),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRoleId = c.Int(),
                        LoginDataId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoginData", t => t.LoginDataId, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.LoginDataId);
            
            CreateTable(
                "dbo.LoginData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tourist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 30),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PotentionalTourists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(),
                        TouristId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId)
                .ForeignKey("dbo.Tourist", t => t.TouristId)
                .Index(t => t.TourId)
                .Index(t => t.TouristId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FutureTours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.PastTours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourCities",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.City_Id })
                .ForeignKey("dbo.Tour", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.City", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.TourCountries",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Country_Id })
                .ForeignKey("dbo.Tour", t => t.Tour_Id, cascadeDelete: false)
                .ForeignKey("dbo.Country", t => t.Country_Id, cascadeDelete: false)
                .Index(t => t.Tour_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.TourEmployees",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Employee_Id })
                .ForeignKey("dbo.Tour", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TourTourists",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Tourist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Tourist_Id })
                .ForeignKey("dbo.Tour", t => t.Tour_Id, cascadeDelete: false)
                .ForeignKey("dbo.Tourist", t => t.Tourist_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Tourist_Id);
            
            CreateTable(
                "dbo.PictureAttractions",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Attraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Attraction_Id })
                .ForeignKey("dbo.Picture", t => t.Picture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attraction", t => t.Attraction_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Attraction_Id);
            
            CreateTable(
                "dbo.PictureHotels",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Hotel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Hotel_Id })
                .ForeignKey("dbo.Picture", t => t.Picture_Id, cascadeDelete: false)
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.AttractionHotels",
                c => new
                    {
                        Attraction_Id = c.Int(nullable: false),
                        Hotel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Attraction_Id, t.Hotel_Id })
                .ForeignKey("dbo.Attraction", t => t.Attraction_Id, cascadeDelete: false)
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id, cascadeDelete: false)
                .Index(t => t.Attraction_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.AttractionTours",
                c => new
                    {
                        Attraction_Id = c.Int(nullable: false),
                        Tour_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Attraction_Id, t.Tour_Id })
                .ForeignKey("dbo.Attraction", t => t.Attraction_Id, cascadeDelete: false)
                .ForeignKey("dbo.Tour", t => t.Tour_Id, cascadeDelete: false)
                .Index(t => t.Attraction_Id)
                .Index(t => t.Tour_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttractionTours", "Tour_Id", "dbo.Tour");
            DropForeignKey("dbo.AttractionTours", "Attraction_Id", "dbo.Attraction");
            DropForeignKey("dbo.AttractionHotels", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.AttractionHotels", "Attraction_Id", "dbo.Attraction");
            DropForeignKey("dbo.PictureHotels", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.PictureHotels", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.PictureAttractions", "Attraction_Id", "dbo.Attraction");
            DropForeignKey("dbo.PictureAttractions", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.Hotel", "CityId", "dbo.City");
            DropForeignKey("dbo.TourTourists", "Tourist_Id", "dbo.Tourist");
            DropForeignKey("dbo.TourTourists", "Tour_Id", "dbo.Tour");
            DropForeignKey("dbo.PastTours", "TourId", "dbo.Tour");
            DropForeignKey("dbo.FutureTours", "TourId", "dbo.Tour");
            DropForeignKey("dbo.TourEmployees", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.TourEmployees", "Tour_Id", "dbo.Tour");
            DropForeignKey("dbo.User", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.Tourist", "UserId", "dbo.User");
            DropForeignKey("dbo.PotentionalTourists", "TouristId", "dbo.Tourist");
            DropForeignKey("dbo.PotentionalTourists", "TourId", "dbo.Tour");
            DropForeignKey("dbo.User", "LoginDataId", "dbo.LoginData");
            DropForeignKey("dbo.Employee", "UserId", "dbo.User");
            DropForeignKey("dbo.TourCountries", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.TourCountries", "Tour_Id", "dbo.Tour");
            DropForeignKey("dbo.TourCities", "City_Id", "dbo.City");
            DropForeignKey("dbo.TourCities", "Tour_Id", "dbo.Tour");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropIndex("dbo.AttractionTours", new[] { "Tour_Id" });
            DropIndex("dbo.AttractionTours", new[] { "Attraction_Id" });
            DropIndex("dbo.AttractionHotels", new[] { "Hotel_Id" });
            DropIndex("dbo.AttractionHotels", new[] { "Attraction_Id" });
            DropIndex("dbo.PictureHotels", new[] { "Hotel_Id" });
            DropIndex("dbo.PictureHotels", new[] { "Picture_Id" });
            DropIndex("dbo.PictureAttractions", new[] { "Attraction_Id" });
            DropIndex("dbo.PictureAttractions", new[] { "Picture_Id" });
            DropIndex("dbo.TourTourists", new[] { "Tourist_Id" });
            DropIndex("dbo.TourTourists", new[] { "Tour_Id" });
            DropIndex("dbo.TourEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.TourEmployees", new[] { "Tour_Id" });
            DropIndex("dbo.TourCountries", new[] { "Country_Id" });
            DropIndex("dbo.TourCountries", new[] { "Tour_Id" });
            DropIndex("dbo.TourCities", new[] { "City_Id" });
            DropIndex("dbo.TourCities", new[] { "Tour_Id" });
            DropIndex("dbo.PastTours", new[] { "TourId" });
            DropIndex("dbo.FutureTours", new[] { "TourId" });
            DropIndex("dbo.PotentionalTourists", new[] { "TouristId" });
            DropIndex("dbo.PotentionalTourists", new[] { "TourId" });
            DropIndex("dbo.Tourist", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "LoginDataId" });
            DropIndex("dbo.User", new[] { "UserRoleId" });
            DropIndex("dbo.Employee", new[] { "UserId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropIndex("dbo.Hotel", new[] { "CityId" });
            DropTable("dbo.AttractionTours");
            DropTable("dbo.AttractionHotels");
            DropTable("dbo.PictureHotels");
            DropTable("dbo.PictureAttractions");
            DropTable("dbo.TourTourists");
            DropTable("dbo.TourEmployees");
            DropTable("dbo.TourCountries");
            DropTable("dbo.TourCities");
            DropTable("dbo.Picture");
            DropTable("dbo.PastTours");
            DropTable("dbo.FutureTours");
            DropTable("dbo.UserRole");
            DropTable("dbo.PotentionalTourists");
            DropTable("dbo.Tourist");
            DropTable("dbo.LoginData");
            DropTable("dbo.User");
            DropTable("dbo.Employee");
            DropTable("dbo.Tour");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Hotel");
            DropTable("dbo.Attraction");
        }
    }
}
