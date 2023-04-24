using System;
using ADACA.Domain;

namespace ADACA.Application
{
	public interface ILoanRepository
	{
        Task<Loan> addLoanWeb(Loan loan);
        Task<bool> addLoanApi(Loan loan);
        Task<IEnumerable<LoanAmountConfig>> getLoanConfig();
    }
}

