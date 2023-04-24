using System;
using System.ComponentModel.DataAnnotations;

namespace ADACA.Domain
{
	public class Loan
    {
        public int loanId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string businessNumber { get; set; }
        public decimal loanAmount { get; set; }
        public Citizen citizen { get; set; }       
        public int timeTrading { get; set; }
        public string countryCode { get; set; }
        public string industry { get; set; }
	}
}

