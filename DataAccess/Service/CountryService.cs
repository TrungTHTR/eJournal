using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class CountryService : ICountryService
	{
		private readonly IUnitOfWork _unitOfWork;
		public CountryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<List<Country>> GetAllCountry()
		{
			return await _unitOfWork.CountryRepository.GetAll();
		}
	}
}
