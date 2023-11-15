using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public enum Bonus
    {
        [Display(Name = "0%")]
        _1,
        [Display(Name = "5%")]
        _5,
        [Display(Name = "10%")]
        _10,
        [Display(Name = "20%")]
        _20
    }
    public class Salaries
    {
        [Key] public int Salary_ID { get; set; }

        // This regular expression only allows values of 1.00-99999999999999999.99 while allowing the optional input of 0,1 or 2 decimal points
        [Column(TypeName = "decimal(19,2)")]
        [DisplayName("Salary($)")]
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,16}(\\.\\d{1,2})?)$", ErrorMessage = "Please input a valid amount of money")]
        public decimal Salary { get; set; }

        // This regular expression only allows values of 1.00-999.99 while allowing the optional input of 0,1 or 2 decimal points
        [Column(TypeName = "decimal(5,2)")]
        [DisplayName("Wage($)")]
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,2}(\\.\\d{1,2})?)$", ErrorMessage = "Please input a valid amount of money")]
        public decimal Wage { get; set; }
        public Bonus Bonus { get; set; }
        public ICollection<Payroll> Payrolls { get; } = new List<Payroll>();
    }
}