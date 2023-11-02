using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
	public class Topic
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TopicId { get; set; }
		public string TopicName { get; set; }
		public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
	}
}
