using System;
using ADACA.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ADACA.Validator
{
	public static class ValidatePhoneNumber
	{
        public static string? Validation(LoanDto model)
        {
            var message = "Invalid Phone number format.";
            if (model.mobileType == "Mobile")
            {
                if (model.phoneNumber?.Length == 10 || model.phoneNumber?.Length == 12)
                {

                    if (model.phoneNumber.Substring(0, 2) != "04" & model.phoneNumber.Substring(0, 4) != "+614")
                    {
                        return message;
                    }
                }
                else
                {
                    return message;
                }
            } else
            {
                if (model.phoneNumber?.Length == 10)
                {
                    var formats = new List<string> { "02", "03", "07" };
                    var code = model.phoneNumber.Substring(0, 2);

                    var valid = formats.Where(x => x == code);

                    if (!valid.Any())
                    {
                        return message;
                    }
          
                }
            }
            return null;
        }

    }
}

