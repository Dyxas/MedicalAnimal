namespace MedicalAnimal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrganizationCards", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrganizationCards", "City");
        }
    }
}
