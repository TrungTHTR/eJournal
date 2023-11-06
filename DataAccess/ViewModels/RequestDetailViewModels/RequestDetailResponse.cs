using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.RequestDetailViewModels
{
    public class RequestDetailResponse
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string? Comments { get; set; }
        public Guid RequestId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public Guid? ModificationBy { get; set; }
    }
}
