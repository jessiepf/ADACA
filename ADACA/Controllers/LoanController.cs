using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ADACA.Application;
using ADACA.Models;
using ADACA.Validator;
using ADACA.Dto;
using ADACA.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using AutoMapper;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADACA.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;
        public LoanController(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;

        }
        // GET: /<controller>/
        public IActionResult Loan()
        {
            return View(new LoanDto());
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> Loan(LoanDto loanWeb)
        {

            var result = ValidatePhoneNumber.Validation(loanWeb);

            if (result != null)
            {
                ModelState.AddModelError("phoneNumber", result);
            }

            if (loanWeb.citizen == 0)
            {
                ModelState.AddModelError("citizen", "Citizen is required.");
            }

            if (ModelState.IsValid)
            {
                Loan loan = _mapper.Map<Loan>(loanWeb);
                var response = await _loanService.addLoanApi(loan);

                return  await  _loanService.addLoan(loan);
            }
               
            return View(loanWeb);
        }
    }
}

