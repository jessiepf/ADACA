using ADACA.Application;
using ADACA.Domain;
using ADACA.Dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace ADACA.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;
    private readonly IMapper _mapper;
    public LoanController(ILoanService loanService, IMapper mapper)
    {
        _loanService = loanService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Response>> Loan(LoanDtoApi loanApi)
    {
        Loan loan = _mapper.Map<Loan>(loanApi);
        var response = await _loanService.addLoanApi(loan);

        return Ok(new { data = response });

    }
}

