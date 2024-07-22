using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
