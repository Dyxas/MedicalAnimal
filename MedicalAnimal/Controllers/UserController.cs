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
                Login = "curator_vet",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_vet" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "curator_otlov",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_otlov" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "curator_priut",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "operator_vet",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 2, Name = "operator_vet" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "curator_priut",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "podpisant_vet",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 0, ContractAccess = 1, InspectionAccess = 1, OrganizationAccess = 2, Name = "podpisant_vet" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "podpisant_otlov",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "podpisant_otlov" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "curator_priut",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "curator_omsu",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });

            db.Users.Add(new User
            {
                Login = "operator_omsu",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 2, InspectionAccess = 0, OrganizationAccess = 2, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "podpisant_omsu",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 1, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 1, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "operator_priut",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 2, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 0, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
            db.Users.Add(new User
            {
                Login = "vet_doctor",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 2, ContractAccess = 1, InspectionAccess = 0, OrganizationAccess = 0, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });

            db.Users.Add(new User
            {
                Login = "vet_doctor_priut",
                Password = "test",
                Role = new RoleDTO { AnimalAccess = 2, ContractAccess = 0, InspectionAccess = 0, OrganizationAccess = 0, Name = "curator_priut" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });
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
