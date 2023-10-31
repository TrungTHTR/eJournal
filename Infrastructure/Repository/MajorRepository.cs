using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public class MajorRepository : GenericRepository<Major>, IMajorRepository
	{
		public MajorRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
		{
		}
	}
}
