using System;
using ADACA.Application;
using ADACA.Domain;
using Microsoft.EntityFrameworkCore;

namespace ADACA.Infrastructure
{
	public class LoanRepository : ILoanRepository
	{
        private readonly LoanContext _loanContext;

        public LoanRepository(LoanContext loanContext)
		{
            _loanContext = loanContext;
		}

        public async Task<bool> addLoanApi(Loan loan)
        {
            try {
                _loanContext.Loans.Add(loan);
                await _loanContext.SaveChangesAsync();
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        public async Task<Loan> addLoanWeb(Loan loan)
        {
            try
            {
                _loanContext.Loans.Add(loan);
                await _loanContext.SaveChangesAsync();
                return loan;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }

        public async Task<IEnumerable<LoanAmountConfig>> getLoanConfig()
        { 
            return await _loanContext.LoanAmountConfigs.ToListAsync();  
        }
    }
}

