using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Specialization
{
    public Guid Id { get; set; }

    public string SpecializationName { get; set; } = null!;

    public Guid MajorId { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual ICollection<AccountSpecialization> AccountSpecializations { get; set; } = new List<AccountSpecialization>();

    public virtual Major Major { get; set; } = null!;
}
