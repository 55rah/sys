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

        [Column(TypeName = "decimal(19,2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Wage { get; set; }
        public Bonus Bonus { get; set; }
        public ICollection<Payroll> Payrolls { get; } = new List<Payroll>();
    }
}