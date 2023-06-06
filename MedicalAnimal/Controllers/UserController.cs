using MedicalAnimal.DTO;
using MedicalAnimal.Models;
using System.Linq;

namespace MedicalAnimal.Controllers
{
    class UserController
    {
        private User User { get; set; }

        DatabaseContext db;
        public UserController(DatabaseContext db)
        {
            this.db = db;
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
