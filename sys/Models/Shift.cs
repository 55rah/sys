using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public class Shift
    {
        [Key] public int Shift_ID { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Hours { get; set; }
        public ICollection<Payroll> Payrolls { get; } = new List<Payroll>();
    }
}