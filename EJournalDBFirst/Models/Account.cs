using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? RefreshToken { get; set; }

    public string Address { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime? CreationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModificationDate { get; set; }

    public Guid? ModificationBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? DeletionDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual ICollection<AccountSpecialization> AccountSpecializations { get; set; } = new List<AccountSpecialization>();

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();

    public virtual Role Role { get; set; } = null!;
}
