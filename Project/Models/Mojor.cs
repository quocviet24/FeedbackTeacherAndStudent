using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Mojor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
