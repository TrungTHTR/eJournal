using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserViewModels
{
	public class AuthorResponse
	{
		public Guid Id { get; set; }
		public string AuthorName { get; set; }
		public string IdentityCardNumber { get; set; }
		public Guid? AccountId { get; set; }
	}
}
