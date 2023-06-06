using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.DTO
{
    // 0 - Нет доступа 1 - Просмотр, Поиск, Сортировка 2 - Введение (все CRUD операции)
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalAccess { get; set; }
        public int ContractAccess { get; set; }
        public int OrganizationAccess { get; set; }
        public int InspectionAccess { get; set; }
    }
}
