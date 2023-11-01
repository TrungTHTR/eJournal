using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
	public class Author
	{
		[Key]
		public Guid Id { get; set; }
		public string AuthorName { get; set; }
		public Guid? AccountId { get; set; }
		[ForeignKey(nameof(AccountId))]
		public virtual Account? Account { get; set; }
		public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

	}
}
