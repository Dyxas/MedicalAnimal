using MedicalAnimal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual RoleDTO Role { get; set; }
        public virtual OrganizationCard OrganizationCard { get; set; }
    }
}
