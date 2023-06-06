using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal
{
    /// <summary>
    /// Про миграции https://metanit.com/sharp/entityframework/3.12.php
    /// </summary>
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnectionString")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Models.ModelCardExample> CardsExample { get; set; }
        public DbSet<Models.AnimalCard> AnimalCards { get; set; }
        public DbSet<Models.OrganizationCard> OrganizationCards{ get; set; }
        public DbSet<Models.ContractCard> ContractCards{ get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<DTO.RoleDTO> Roles { get; set; }
        public DbSet<Models.InspectionCard> InspectionCards { get; set; }
    }
}
