using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class RequestReview
{
    public Guid Id { get; set; }

    public string RequestTitle { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public Guid? ArticleId { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Article? Article { get; set; }

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();
}
