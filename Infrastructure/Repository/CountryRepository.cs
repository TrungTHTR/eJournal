using Application.InterfaceRepository;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public  class CountryRepository:ICountryRepository
	{
		private readonly AppDbContext _context;
		public CountryRepository (AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<Country>> GetAll()
		{
			return await _context.Country.ToListAsync();
		}
	}
}
