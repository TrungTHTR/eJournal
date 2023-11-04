using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.RequestDetailViewModels
{
    public class RequestViewStatus
    {
        public int Status { get; set; }
        public string Description { get; set; }
    }
}
