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
    public class AccountSpecializationService : IAccountSpecializeService
    {
        private readonly IUnitOfWork _unitOfWork;   
        public AccountSpecializationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Account>> GetReviewerBySpecialization(string specializationName)
        {
            return await _unitOfWork.AccountSpecializationRepository.GetAccountThroughSpecialize(specializationName);
        }
    }
}
