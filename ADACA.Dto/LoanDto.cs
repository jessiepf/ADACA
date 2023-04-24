using System;

using System.ComponentModel.DataAnnotations;

using ADACA.Domain;
namespace ADACA.Dto
{
	public class LoanDto
	{
        public int loanId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is invalid")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        //[MaxLength(11)]
        public string phoneNumber { get; set; }

        [MinLength(11, ErrorMessage = "Incorrect Business Number")]
        [MaxLength(11)]
        [Display(Name = "Business Number")]
        public string businessNumber { get; set; }

        //[Range(10001, 99999, ErrorMessage = "Loan Amount is invalid")]
        //[RegularExpression("([1-9][0-9]*)")]
        //[Display(Name = "Loan Amount")]
        public decimal loanAmount { get; set; }

        [Display(Name = "Citizenship")]
        public Citizen citizen { get; set; }
        //public string citizenshipStatus { get; set; }

        //public Citizen citizen { get; set; }

        //public string selectedCitizenName { get; set; }

        //[Range(2, 19, ErrorMessage = "TimeTrading can be a number and greater than 1 and less than 20")]
        //[Display(Name = "Time Trading")]
        public int timeTrading { get; set; }

        [Display(Name = "Country Code")]
        public string countryCode { get; set; }

        [Display(Name = "Industry")]
        public string industry { get; set; }
        public string mobileType { get; set; }

        //[MaxLength(9, ErrorMessage = "The Mobile or landline field must be 8 characters long")]
        //[Required(ErrorMessage = "Mobile or Landline is required")]
        //public string mobileText { get; set; }
        //public List<string> mobileCode = new() { "04", "+614" };
        //public List<string> landlineCode = new() { "02", "03","07", "08" };

        //public string mobileSelected { get; set; }
    }
}

