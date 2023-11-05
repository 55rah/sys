using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PMS10.Models
{
    public enum WorkType
    {
        [Display(Name = "Full Time")]
        FullTime,
        [Display(Name = "Part Time")]
        PartTime, 
        Temp, 
        Casual
    }

    public class Employee
    {
        [DisplayName("ID")]
        [Key] public int Employee_ID { get; set; }

        // The [Required] annotation makes the table unable to be created without the field filled
        // This regular expression only validates only 8 or 9 digit numbers 
        [Required(ErrorMessage = "Please enter IRD number")]
        [DisplayName("IRD")]
        [RegularExpression("(^\\d{8}(\\d{1})?$)", ErrorMessage = "Please enter a valid IRD number format e.g. 123456789")]
        public string IRD { get; set; }

        // The [DisplayName] annotation is self explanatory and changes the display name on the web app
        // This regular expression only validates all letters of the alphabet including some special characters for foreign names 
        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("First Name")]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'])+$", ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DisplayName("Last Name")]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'])+$", ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [DisplayName("Work Type")]
        public WorkType WorkType { get; set; }

        // This [DataType(DataType.EmailAddress)] only allows email addresses in the field
        [Required(ErrorMessage = "Please enter an email address")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // This regular expression only allows local, mobile and freecall NZ phone numbers
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

        public ICollection<Payroll> Payrolls { get; } = new List<Payroll>();
    }
}