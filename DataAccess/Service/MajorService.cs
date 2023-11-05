using Application.InterfaceService;
using Application.ViewModels.ArticleViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class MajorService : IMajorService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MajorService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<MajorDTO>> GetAll()
		{
			var majors = await _unitOfWork.MajorRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<MajorDTO>>(majors);
		}
	}
}
