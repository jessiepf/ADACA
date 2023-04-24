using System;
using Microsoft.EntityFrameworkCore;
using ADACA.Domain;
using System.Diagnostics.Metrics;

namespace ADACA.Infrastructure
{
	public class LoanContext : DbContext
	{
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LoanAmountConfig>().HasData(
            new LoanAmountConfig
            {
                Id = 1,
                 aboveAmount = 99999,
                 belowAmount = 10001
            },
            new LoanAmountConfig
            {
                Id = 2,
                aboveAmount = 19,
                belowAmount = 2
            }
        );

            modelBuilder.Entity<Loan>()
               .Property(p => p.loanAmount)
               .HasColumnType("decimal(18,2)");
        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanAmountConfig> LoanAmountConfigs { get; set; }
    }
}

