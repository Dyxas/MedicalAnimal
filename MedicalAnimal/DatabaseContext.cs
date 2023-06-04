using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal
{
    //ttt
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnectionString")
        {

        }

        public DbSet<Models.ModelCardExample> CardsExample { get; set; }
    }
}
