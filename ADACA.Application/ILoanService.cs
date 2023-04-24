using System;
using ADACA.Domain;
using ADACA.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ADACA.Application
{
	public interface ILoanService
	{
        Task<Loan> addLoan(Loan loan);
        Task<Response> addLoanApi(Loan loan);

    }
}

