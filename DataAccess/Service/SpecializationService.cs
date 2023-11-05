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
    public class SpecializationService : ISpecializeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecializationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetSpecializeName()
        {
           return  _unitOfWork.SpecializationRepository.GetAllSpecializationsNameAsync();
        }
    }
}
