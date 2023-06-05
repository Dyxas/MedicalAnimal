using System;

namespace MedicalAnimal.Models
{
    public class OrganizationCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Address { get; set; }
        public string OrganizationType { get; set; }
        public string OwnerType { get; set; }
    }
}
