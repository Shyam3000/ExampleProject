using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Data
{
    public class DispatcherData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PartyName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
