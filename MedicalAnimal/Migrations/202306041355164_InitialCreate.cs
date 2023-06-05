namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalCards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        registrationNumber = c.Int(nullable: false),
                        city = c.String(),
                        category = c.String(),
                        sex = c.String(),
                        birthday = c.DateTime(nullable: false),
                        chipId = c.Int(nullable: false),
                        picture = c.String(),
                        uniqueTreats = c.String(),
                        ownerTreats = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModelCardExamples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModelCardExamples");
            DropTable("dbo.AnimalCards");
        }
    }
}
