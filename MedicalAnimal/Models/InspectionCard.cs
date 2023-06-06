using System;

namespace MedicalAnimal.Models
{
    public class InspectionCard
    {
        public int Id { get; set; }
        public virtual AnimalCard Animal { get; set; }
        public string UniqueBehavior { get; set; }
        public string HealthStatus { get; set; }
        public float Temperature { get; set; }
        public string Skin { get; set; }
        public string FurStatus { get; set; }
        public string HealthDeviations { get; set; }
        public bool IsSerioslyInjured { get; set; }
        public string Diagnosis { get; set; }
        public string CompletedOperations { get; set; }
        public bool NeedHeal { get; set; } 
        public DateTime Date { get; set; }
        public string SpecialistFullName { get; set; }
        public string SpecialistDegree { get; set; }
        public string Role { get; set; }
        public virtual OrganizationCard VetClinic { get; set; }
        public virtual ContractCard Contract { get; set; }

    }
}
