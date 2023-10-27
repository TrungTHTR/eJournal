using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Major
{
    public Guid Id { get; set; }

    public string MajorName { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
}
