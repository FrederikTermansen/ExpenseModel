using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        
        //? Makes Description nullable
        [Required] //Following guide don't understand why i want it required yet
        public string? Description { get; set; }
    }
}