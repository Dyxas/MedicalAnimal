namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganizationCardMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Inn = c.String(),
                        Kpp = c.String(),
                        Address = c.String(),
                        OrganizationType = c.String(),
                        OwnerType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrganizationCards");
        }
    }
}
