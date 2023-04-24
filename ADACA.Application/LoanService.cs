using System;
using System.Reflection;
using ADACA.Domain;
using ADACA.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Industry = ADACA.Domain.Industry;

namespace ADACA.Application
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        
        List<ValidationResult> _validationResults;

        readonly List<IndustryDto> industries = new List<IndustryDto> {
           new IndustryDto { name = "Industry 1", status = Status.Qualified.ToString() },
           new IndustryDto { name =  "Industry 2", status = Status.Qualified.ToString() },
           new IndustryDto{ name = "Banned Industry 1", status = Status.Unqualified.ToString()}
           };

        public LoanService(ILoanRepository loanRepository)
		{
            _loanRepository = loanRepository;
        }

        public async Task<Loan> addLoan(LoanDto loanDto)
        {
            var loan = new Loan();

            loan.firstName = loanDto.firstName;
            loan.lastName = loanDto.lastName;
            loan.citizen =   loanDto.citizen;
            loan.countryCode = loanDto.countryCode;
            loan.emailAddress = loanDto.emailAddress;
            loan.loanAmount = loanDto.loanAmount;
            loan.phoneNumber = loanDto.phoneNumber;
            loan.businessNumber = loanDto.businessNumber;
            loan.industry = loanDto.industry;
            loan.timeTrading = loanDto.timeTrading;
            return await _loanRepository.addLoanWeb(loan);
        }

        public async Task<Response> addLoanApi(Loan loan)
        {
            Response response = new Response();
            _validationResults = new List<ValidationResult>();

            var decision = validateIndustry(loan.industry);
            response.decision = decision;

            var config = await _loanRepository.getLoanConfig();

            validateLoanAmount(loan.loanAmount, decision, config.First());
            validateTimeTrading(loan.timeTrading, decision, config.Last());
            
            await validateBusinessNumber(loan.businessNumber, decision);
            await validatePhoneNumber(loan.phoneNumber,decision);

            if (_validationResults.Count == 0)
            {
                var hasError = await _loanRepository.addLoanApi(loan);

                if (hasError)
                {
                    var ValidationResult = new ValidationResult();

                    ValidationResult.message = "Error while saving";
                    ValidationResult.rule = "Database";
                    _validationResults.Add(ValidationResult);
                }
                return response;
            }

            response.validationResult = _validationResults;

            return response;
           
        }
        
        private string validateIndustry(string industry)
        {
            var result = industries.Where(i => i.name.ToLower() == industry.ToLower()).SingleOrDefault();
            var ValidationResult = new ValidationResult();

            if (result == null)
            {
                setValidation("Unknown industry status", Status.Unknown.ToString(), "Industry");

                return Status.Unknown.ToString();
            }

            if (result.status == Status.Unqualified.ToString())
            {
                setValidation("Unqualified industry status", Status.Unqualified.ToString(), "Industry");
            }

            return result.status;
        }

        private async Task validatePhoneNumber(string phoneNumber,string decision)
        {
            var validPhoneNumber = true;
            if (phoneNumber.Length == 10 || phoneNumber.Length == 12)
            {
                var landlineFormat = phoneNumber.Substring(0, 2);
                var mobileFormat = phoneNumber.Substring(0, 4);
                var formats = new List<string> { "02", "03", "04", "07", "+614" };

                var valid = formats.Where(x => x == landlineFormat || x == mobileFormat);

                if (!valid.Any())
                {
                    validPhoneNumber = false;
                }
            }else
            {
                validPhoneNumber = false;
            }

            if (!validPhoneNumber)
            {
                setValidation("Invalid Phone number format", decision, "Phonenumber");
            }
            await Task.Delay(1000);
        }

        private void validateLoanAmount(decimal loan, string decision, LoanAmountConfig loanAmountConfig)
        {
            if (loan < loanAmountConfig.belowAmount || loan > loanAmountConfig.aboveAmount)
            {
                setValidation("Loan Amount is invalid", decision, "Loanamount");
            }
        }

        private void validateTimeTrading(int timeTrading, string decision, LoanAmountConfig loanAmountConfig)
        {
            if (timeTrading < loanAmountConfig.belowAmount || timeTrading > loanAmountConfig.aboveAmount)
            {
                setValidation("Time trading is invalid", decision, "Timetrading");
            }
        }

        private async Task validateBusinessNumber(string businessNumber, string decision)
        {
            if (businessNumber.Length != 11)
            {
                setValidation("Incorrect Business Number", decision, "businessNumber");
            }
            await Task.Delay(1000);
        }

        private void setValidation(string message, string decision, string rule)
        {
            var ValidationResult = new ValidationResult();

            ValidationResult.message = message;
            ValidationResult.rule = rule;
            ValidationResult.decision = decision;
            _validationResults.Add(ValidationResult);

        }

        public Task<LoanAmountConfig> getLoanConfig()
        {
            throw new NotImplementedException();
        }
    }
}

