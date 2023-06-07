using MedicalAnimal.DTO;
using MedicalAnimal.Models;
using System;
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
                Role = new RoleDTO { AnimalAccess = 2, ContractAccess = 2, InspectionAccess = 2, OrganizationAccess = 2, Name = "test" },
                OrganizationCard = new OrganizationCard { Name = "test", Inn = "232131", Address = "XXX" }
            });

            db.AnimalCards.Add(new AnimalCard
            {
                RegistrationNumber = 1232,
                Name = "Сова",
                City = "Уфа",
                Category = "Собака",
                Sex = "М",
                Birthday = DateTime.Parse("22.03.2021"),
                ChipId = 3,
                OwnerTreats = "Ошейник",
                UniqueTreats = "На ноге большая шишка"
            });
            db.AnimalCards.Add(new AnimalCard
            {
                RegistrationNumber = 1232,
                Name = "Боня",
                City = "Екатеринбург",
                Category = "Кот",
                Sex = "М",
                Birthday = DateTime.Parse("13.07.2013"),
                ChipId = 4,
                OwnerTreats = "Отсутствует",
                UniqueTreats = "Белая-чёрная шёрстка"
            });
            db.AnimalCards.Add(new AnimalCard
            {
                RegistrationNumber = 1232,
                Name = "Кега",
                City = "Тюмень",
                Category = "Кошка",
                Sex = "Ж",
                Birthday = DateTime.Parse("24.11.2020"),
                ChipId = 5,
                OwnerTreats = "Ошейник",
                UniqueTreats = "Отсутствует"
            });
            db.OrganizationCards.Add(new OrganizationCard
            {
                Name = "Аргумент",
                Inn = "7727563778",
                Kpp = "770701001",
                Address = "Тюмень, ул.Николая Федорова 17",
                OrganizationType = "Благотворительная",
                OwnerType = "ИП"
            });
            db.OrganizationCards.Add(new OrganizationCard
            {
                Name = "Квазис",
                Inn = "7727563733",
                Kpp = "770701093",
                Address = "Москва, ул. Ломоносова 133к1",
                OrganizationType = "Коммерческая",
                OwnerType = "Юридическое лицо"
            });
            db.OrganizationCards.Add(new OrganizationCard
            {
                Name = "ГСС",
                Inn = "7727563312",
                Kpp = "771201032",
                Address = "Тюмень, ул. Широтная 16А",
                OrganizationType = "Благотворительная",
                OwnerType = "ИП"
            });

            db.ContractCards.Add(new ContractCard
            {
                Price = 44000,
                Number = "5456",
                StartDate = DateTime.Parse("07.06.2023"),
                EndDate = DateTime.Parse("13.06.2023"),
                Customer = "УРБАН",
                Executor = "ГСС"
            });
            db.ContractCards.Add(new ContractCard
            {
                Price = 3300,
                Number = "5457",
                StartDate = DateTime.Parse("07.06.2023"),
                EndDate = DateTime.Parse("10.06.2023"),
                Customer = "СКА",
                Executor = "ГСС"
            });
            db.ContractCards.Add(new ContractCard
            {
                Price = 65000,
                Number = "5458",
                StartDate = DateTime.Parse("07.06.2023"),
                EndDate = DateTime.Parse("28.06.2023"),
                Customer = "FG",
                Executor = "Квазис"
            });

            db.InspectionCards.Add(new InspectionCard
            {
                Animal = db.AnimalCards.Local.First(),
                NeedHeal = true,
                Skin = "Dsd",
                CompletedOperations = "dsds",
                Contract = db.ContractCards.Local.First(),
                VetClinic = db.OrganizationCards.Local.First(),
                Date = DateTime.Now
            });
            db.InspectionCards.Add(new InspectionCard
            {
                Animal = db.AnimalCards.Local.First(),
                NeedHeal = false,
                Skin = "Dsddsa",
                CompletedOperations = "dsds",
                Contract = db.ContractCards.Local.First(),
                VetClinic = db.OrganizationCards.Local.First(),
                Date = DateTime.Now
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
