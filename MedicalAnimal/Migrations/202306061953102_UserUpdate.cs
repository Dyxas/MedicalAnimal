namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AnimalAccess = c.Int(nullable: false),
                        ContractAccess = c.Int(nullable: false),
                        OrganizationAccess = c.Int(nullable: false),
                        InspectionAccess = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.RoleDTOes", "Id");
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
            DropForeignKey("dbo.Users", "Role_Id", "dbo.RoleDTOes");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropColumn("dbo.Users", "Role_Id");
            DropTable("dbo.RoleDTOes");
        }
    }
}
