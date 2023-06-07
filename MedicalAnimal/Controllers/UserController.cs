using MedicalAnimal.DTO;
using MedicalAnimal.Models;
using System.Linq;

namespace MedicalAnimal.Controllers
{
    internal class UserController
    {
        private User User { get; set; }

        DatabaseContext db;
        public UserController(DatabaseContext db)
        {
            this.db = db;
            db.Users.Add(new User
            {
                Login = "test",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 0, ContractAccess = 2, InspectionAccess = 1, OrganizationAccess = 1, Name = "test" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.SaveChanges();
        }

        public bool Auth(AuthFormDTO authFormDTO) // TODO:: MD5 HASH
        {
            User user = db.Users.Where(a => a.Login == authFormDTO.Login && a.Password == authFormDTO.Password).FirstOrDefault();

            if (user != null)
            {
                User = user;
                return true;
            }

            return false;
        }
        
        public User GetUserInfo()
        {
            return User;
        }

    }
}
