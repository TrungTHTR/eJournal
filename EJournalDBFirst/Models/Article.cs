using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Article
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public Guid IssueId { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Issue Issue { get; set; } = null!;

    public virtual ICollection<RequestReview> RequestReviews { get; set; } = new List<RequestReview>();
}
