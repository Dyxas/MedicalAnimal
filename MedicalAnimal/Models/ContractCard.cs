using System;

namespace MedicalAnimal.Models
{
    public class ContractCard
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Customer { get; set; }
        public string Executor { get; set; }
    }
}
