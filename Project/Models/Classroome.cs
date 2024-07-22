using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Classroome
{
    public int Id { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<FeedbacksCurent> FeedbacksCurents { get; set; } = new List<FeedbacksCurent>();

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
}
