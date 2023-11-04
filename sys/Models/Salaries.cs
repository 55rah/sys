using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS10.Models
{
    public enum Bonus
    {
        _1, _2, _3, _4
    }
    public class Salaries
    {
        [Key] public int Salary_ID { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal Wage { get; set; }
        public Bonus Bonus { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}