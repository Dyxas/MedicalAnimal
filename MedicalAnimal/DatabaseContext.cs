﻿using System;
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

        }

        public DbSet<Models.ModelCardExample> CardsExample { get; set; }
        public DbSet<Models.AnimalCard> AnimalCards { get; set; }
        public DbSet<Models.OrganizationCard> OrganizationCards{ get; set; }
    }
}
