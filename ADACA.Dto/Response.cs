using System;
namespace ADACA.Dto
{
	public class Response
	{
        public string decision { get; set; }
        public IEnumerable<ValidationResult> validationResult { get; set; }
    }
}

