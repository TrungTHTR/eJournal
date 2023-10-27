using System;
using System.Collections.Generic;

namespace EJournalDBFirst.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Rolename { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
