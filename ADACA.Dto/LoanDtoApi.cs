using System;

using System.ComponentModel.DataAnnotations;

using ADACA.Domain;
namespace ADACA.Dto
{
	public class LoanDtoApi
	{
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
        public string phoneNumber { get; set; }

        public string businessNumber { get; set; }

        public decimal loanAmount { get; set; }

        [Display(Name = "Citizenship")]
        public Citizen citizen { get; set; }
       
        public int timeTrading { get; set; }

        [Display(Name = "Country Code")]
        public string countryCode { get; set; }

        [Display(Name = "Industry")]
        public string industry { get; set; }
    }
}

