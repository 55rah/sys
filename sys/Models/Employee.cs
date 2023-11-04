using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PMS10.Models
{
    public enum WorkType
    {
        FullTime, PartTime, Temp, Casual
    }

    public class Employee
    {
        [Key] public int Employee_ID { get; set; }

        [Required(ErrorMessage = "Please enter IRD number")]
        [DisplayName("IRD")]
        [RegularExpression("(^\\d{8}(\\d{1})?$)", ErrorMessage = "Please enter a valid IRD number format e.g. 123456789")]
        public string IRD { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("First Name")]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'])+$", ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DisplayName("Last Name")]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'])+$", ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        public WorkType WorkType { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("(^\\([0]\\d{1}\\))(\\d{7}$)|(^\\([0][2]\\d{1}\\))(\\d{6,8}$)|([0][8][0][0])([\\s])(\\d{5,8}$)", ErrorMessage = "Please enter a valid phone number format e.g. (021)1234567")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a region")]
        [DisplayName("Region")]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'])+$", ErrorMessage = "Please enter a region")]
        public string Region { get; set; }
        public bool COA { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}