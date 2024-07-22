using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Role
{
    public int Id { get; set; }

    public string NameRole { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
