using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Frequency
{
    public int Id { get; set; }

    public string? Fre { get; set; }

    public virtual ICollection<FeedbacksCurent> FeedbacksCurentFreAnsNavigations { get; set; } = new List<FeedbacksCurent>();

    public virtual ICollection<FeedbacksCurent> FeedbacksCurentFreFullLessionNavigations { get; set; } = new List<FeedbacksCurent>();

    public virtual ICollection<FeedbacksCurent> FeedbacksCurentFreOnTimeNavigations { get; set; } = new List<FeedbacksCurent>();
}
