using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Issue
{
    public Guid Id { get; set; }

    public string Volumn { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateRelease { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
