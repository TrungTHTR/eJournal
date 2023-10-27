using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class RequestDetail
{
    public Guid Id { get; set; }

    public int Status { get; set; }

    public string Description { get; set; } = null!;

    public string? Comments { get; set; }

    public Guid? RequestId { get; set; }

    public Guid RequestReviewId { get; set; }

    public Guid? AccountId { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Account? Account { get; set; }

    public virtual RequestReview RequestReview { get; set; } = null!;
}
