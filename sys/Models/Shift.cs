using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public class Shift
    {
        [Key] public int Shift_ID { get; set; }

        // This regular expression only allows values of 1.00-99.99 while allowing the optional input of 0,1 or 2 decimal points
        [Column(TypeName = "decimal(4,2)")]
        [RegularExpression("^(?!0\\\\.00)([1-9]\\d?(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a valid number")]
        public decimal Hours { get; set; }
        public ICollection<Payroll> Payrolls { get; } = new List<Payroll>();
    }
}