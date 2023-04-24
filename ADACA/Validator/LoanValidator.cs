using System;
using ADACA.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ADACA.Validator
{
	public static class LoanValidator
	{
        public static bool SaveValidation(LoanDto model, ModelStateDictionary modelState)
        {
            var response = new Response();
            //var validation = new Response();
            //var items = new ValidationResult[]();
            var validationResults = new List<ValidationResult>();
            var ValidationResult = new ValidationResult();
            if (model.firstName == null)
            {
                ValidationResult.rule = "First Name";
                ValidationResult.message = "First Name is required.";
                ValidationResult.decision = "Unknown";
                response.decision = "Unknown";
                validationResults.Add(ValidationResult);
            }

            if (model.firstName == null)
            {
                ValidationResult.rule = "First Name";
                ValidationResult.message = "First Name is required.";
                ValidationResult.decision = "Unknown";
                response.decision = "Unknown";
                validationResults.Add(ValidationResult);
            }

            return modelState.IsValid;
        }
    }
}

