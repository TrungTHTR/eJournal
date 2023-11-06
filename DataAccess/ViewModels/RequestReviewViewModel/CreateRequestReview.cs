using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.RequestReviewViewModel
{
	public  class CreateRequestReview
	{
		public Guid? Id { get; set; }	
		public string RequestTitle { get; set; }
		public DateTime RequestDate { get; set; }
		public Guid? ArticleId { get; set; }
	}
}
