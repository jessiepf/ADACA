using System;
using AutoMapper;
using ADACA.Domain;
using ADACA.Dto;

namespace ADACA.Helper
{
	public class AutomapperConfig : Profile
	{
		public AutomapperConfig()
		{
            CreateMap<LoanDto, Loan>().ReverseMap();
        }
	}
}

