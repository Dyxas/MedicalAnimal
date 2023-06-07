using MedicalAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.DTO
{
    internal class InspectionDTO
    {
        public int Id { get; set; }
        public string Animal { get; set; }
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
        public string VetClinic { get; set; }
        public string Contract { get; set; }
        public InspectionDTO(InspectionCard card){
            Id = card.Id;
            Animal = $"{card.Animal.Name}:{card.Animal.RegistrationNumber}:{card.Animal.Category}";
            UniqueBehavior = card.UniqueBehavior;
            HealthStatus = card.HealthStatus;
            Temperature = card.Temperature;
            Skin = card.Skin;
            FurStatus = card.FurStatus;
            HealthDeviations= card.HealthDeviations;
            Diagnosis= card.Diagnosis;
            CompletedOperations= card.CompletedOperations;
            NeedHeal= card.NeedHeal;
            Date = card.Date;
            SpecialistFullName = card.SpecialistFullName;
            SpecialistDegree = card.SpecialistDegree;
            Role = card.Role;
            VetClinic = $"{card.VetClinic.Name}:{card.VetClinic.Kpp}:{card.VetClinic.Address}:{card.VetClinic.City}:{card.VetClinic.OrganizationType}:{card.VetClinic.OwnerType}";
            Contract = $"{card.Contract.Number}:{card.Contract.Price}:{card.Contract.Executor}:{card.Contract.Customer}:{card.Contract.StartDate}:{card.Contract.EndDate}:";
        }
    }
}
