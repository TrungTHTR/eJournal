using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class AccountSpecialization
{
    public Guid AccountId { get; set; }

    public Guid SpecializationId { get; set; }

    public int ConfidentLevel { get; set; }

    public Guid Id { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Specialization Specialization { get; set; } = null!;
}
