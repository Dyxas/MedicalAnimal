namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        OrganizationCard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationCards", t => t.OrganizationCard_Id)
                .Index(t => t.OrganizationCard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OrganizationCard_Id", "dbo.OrganizationCards");
            DropIndex("dbo.Users", new[] { "OrganizationCard_Id" });
            DropTable("dbo.Users");
        }
    }
}
