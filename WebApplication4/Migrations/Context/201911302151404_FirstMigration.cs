namespace WebApplication4.Migrations.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        NumberPlate = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Model = c.Int(nullable: false),
                        Make = c.String(nullable: false),
                        PetrolInLitres = c.Double(nullable: false),
                        DrivenInKms = c.Double(nullable: false),
                        Rating = c.Int(nullable: false),
                        Cnic = c.String(nullable: false, maxLength: 128),
                        EngineCC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumberPlate)
                .ForeignKey("dbo.People", t => t.Cnic, cascadeDelete: true)
                .Index(t => t.Cnic);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Cnic = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        PaymentBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Cnic);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        PhoneNo = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        NumberPlate = c.String(maxLength: 128),
                        Cnic = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Paymentbalance = c.Double(nullable: false),
                        FineAmount = c.Double(nullable: false),
                        YearsOfExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNo)
                .ForeignKey("dbo.Cars", t => t.NumberPlate)
                .Index(t => t.NumberPlate);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        NumberPlate = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NumberPlate)
                .ForeignKey("dbo.Cars", t => t.NumberPlate)
                .Index(t => t.NumberPlate);
            
            CreateTable(
                "dbo.UberRentedCars",
                c => new
                    {
                        NumberPlate = c.String(nullable: false, maxLength: 128),
                        Cnic = c.String(nullable: false, maxLength: 128),
                        EstimateHours = c.Int(nullable: false),
                        EstimateKilometers = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NumberPlate)
                .ForeignKey("dbo.Cars", t => t.NumberPlate)
                .ForeignKey("dbo.People", t => t.Cnic, cascadeDelete: true)
                .Index(t => t.NumberPlate)
                .Index(t => t.Cnic);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UberRentedCars", "Cnic", "dbo.People");
            DropForeignKey("dbo.UberRentedCars", "NumberPlate", "dbo.Cars");
            DropForeignKey("dbo.Insurances", "NumberPlate", "dbo.Cars");
            DropForeignKey("dbo.Drivers", "NumberPlate", "dbo.Cars");
            DropForeignKey("dbo.Cars", "Cnic", "dbo.People");
            DropIndex("dbo.UberRentedCars", new[] { "Cnic" });
            DropIndex("dbo.UberRentedCars", new[] { "NumberPlate" });
            DropIndex("dbo.Insurances", new[] { "NumberPlate" });
            DropIndex("dbo.Drivers", new[] { "NumberPlate" });
            DropIndex("dbo.Cars", new[] { "Cnic" });
            DropTable("dbo.UberRentedCars");
            DropTable("dbo.Insurances");
            DropTable("dbo.Drivers");
            DropTable("dbo.People");
            DropTable("dbo.Cars");
        }
    }
}
