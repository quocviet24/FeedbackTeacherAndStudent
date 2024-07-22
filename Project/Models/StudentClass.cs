using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class StudentClass
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public virtual Classroome Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
