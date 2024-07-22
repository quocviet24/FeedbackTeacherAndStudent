using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Mark
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public double? Assignment1 { get; set; }

    public double? Assignment2 { get; set; }

    public double? ProgressTest1 { get; set; }

    public double? ProgressTest2 { get; set; }

    public double? GroupProject { get; set; }

    public double? Pe { get; set; }

    public double? Fe { get; set; }

    public double? Fer { get; set; }

    public virtual Classroome Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
