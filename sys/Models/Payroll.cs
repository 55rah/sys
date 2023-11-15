using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace PMS10.Models
{
    public class Payroll
    {
        [Key] public int Payroll_ID { get; set; }

        //Foreign key for Employee
        [ForeignKey("Employee")]
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage = "Please enter a valid ID for an employee record")]
        public int Employee_ID { get; set; }
        public Employee? Employee { get; set; }

        //Foreign key for Salary
        [ForeignKey("Salaries")]
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage = "Please enter a valid ID for an salary record")]
        public int Salary_ID { get; set; }
        public Salaries? Salaries { get; set; }

        //Foreign key for Shift
        [ForeignKey("Shift")]
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage = "Please enter a valid ID for an shift record")]
        public int Shift_ID { get; set; }
        public Shift? Shift { get; set; }

        // The [DataType(DataType.Date)] annotation makes the field a date field where a user can select a date from a calender GUI. 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Payroll()
        {
            Date = DateTime.Now;
        }

        // This [Column(TypeName = "decimal(7,2)")] defines the decimal field for TotalAmount where 7 is the allowed amount of total digits in a number and 2 is the amont after a decimal
        [Column(TypeName = "decimal(19,2)")]
        [DisplayName("Total Amount($)")]
        [RegularExpression("^\\$?([1-9]{1}[0-9]{0,2}(\\,[0-9]{3})*(\\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\\.[0-9]{0,2})?|0(\\.[0-9]{0,2})?|(\\.[0-9]{1,2})?)$", ErrorMessage = "Please enter a valid amount of money")]
        public decimal TotalAmount { get; set; }
    }
}