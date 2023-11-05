using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public class Payroll
    {
        [Key] public int Payroll_ID { get; set; }

        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("Salaries")]
        public int Salary_ID { get; set; }
        public Salaries? Salaries { get; set; }

        [ForeignKey("Shift")]
        public int Shift_ID { get; set; }
        public Shift? Shift { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal TotalAmount { get; set; }
    }
}