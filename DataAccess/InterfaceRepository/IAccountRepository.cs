using Application.ViewModels.UserViewModels;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        Task<List<UserViewAllModel>> GetAllWithViewModel();
    }
}
