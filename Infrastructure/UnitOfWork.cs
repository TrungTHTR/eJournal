using Application;
using Application.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRequestDetailRepository _requestDetailRepository;
        public UnitOfWork (IRequestDetailRepository requestDetailRepository)
        {
            _requestDetailRepository = requestDetailRepository;
        }
        public IRequestDetailRepository RequestDetailRepository => _requestDetailRepository;
    }
}
