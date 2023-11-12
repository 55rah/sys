using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public class Payroll
    {
        [Key] public int Payroll_ID { get; set; }

        //Foreign key for Employee
        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }
        public Employee? Employee { get; set; }

        //Foreign key for Salary
        [ForeignKey("Salaries")]
        public int Salary_ID { get; set; }
        public Salaries? Salaries { get; set; }

        //Foreign key for Shift
        [ForeignKey("Shift")]
        public int Shift_ID { get; set; }
        public Shift? Shift { get; set; }

        // The [DataType(DataType.Date)] annotation makes the field a date field where a user can select a date from a calender GUI. 
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // This [Column(TypeName = "decimal(7,2)")] defines the decimal field for TotalAmount where 7 is the allowed amount of total digits in a number and 2 is the amont after a decimal
        [Column(TypeName = "decimal(19,2)")]
        [DisplayName("Total Amount($)")]
        public decimal TotalAmount { get; set; }
    }
}