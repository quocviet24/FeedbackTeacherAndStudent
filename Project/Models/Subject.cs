using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FeedbacksCurent> FeedbacksCurents { get; set; } = new List<FeedbacksCurent>();

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
}
