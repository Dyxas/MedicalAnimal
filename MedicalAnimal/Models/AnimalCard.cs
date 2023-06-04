using System;

namespace MedicalAnimal.Models
{
    public class AnimalCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegistrationNumber { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public int ChipId { get; set; }
        public string Picture { get; set; }
        public string UniqueTreats { get; set; }
        public string OwnerTreats { get; set; }
    }
}
