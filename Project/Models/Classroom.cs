using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<FeedbacksCurent> FeedbacksCurents { get; set; } = new List<FeedbacksCurent>();

    public virtual ICollection<FeedbacksTotal> FeedbacksTotals { get; set; } = new List<FeedbacksTotal>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
}
