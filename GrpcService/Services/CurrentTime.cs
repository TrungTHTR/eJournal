using GrpcService.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService.Service
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
       
    }
}
