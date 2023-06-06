namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInspectionCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectionCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueBehavior = c.String(),
                        HealthStatus = c.String(),
                        Temperature = c.Single(nullable: false),
                        Skin = c.String(),
                        FurStatus = c.String(),
                        HealthDeviations = c.String(),
                        IsSerioslyInjured = c.Boolean(nullable: false),
                        Diagnosis = c.String(),
                        CompletedOperations = c.String(),
                        NeedHeal = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SpecialistFullName = c.String(),
                        SpecialistDegree = c.String(),
                        Role = c.String(),
                        Animal_Id = c.Int(),
                        Contract_Id = c.Int(),
                        VetClinic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalCards", t => t.Animal_Id)
                .ForeignKey("dbo.ContractCards", t => t.Contract_Id)
                .ForeignKey("dbo.OrganizationCards", t => t.VetClinic_Id)
                .Index(t => t.Animal_Id)
                .Index(t => t.Contract_Id)
                .Index(t => t.VetClinic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InspectionCards", "VetClinic_Id", "dbo.OrganizationCards");
            DropForeignKey("dbo.InspectionCards", "Contract_Id", "dbo.ContractCards");
            DropForeignKey("dbo.InspectionCards", "Animal_Id", "dbo.AnimalCards");
            DropIndex("dbo.InspectionCards", new[] { "VetClinic_Id" });
            DropIndex("dbo.InspectionCards", new[] { "Contract_Id" });
            DropIndex("dbo.InspectionCards", new[] { "Animal_Id" });
            DropTable("dbo.InspectionCards");
        }
    }
}
