using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class FeedbacksCurent
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public int ClassId { get; set; }

    public int FreOnTime { get; set; }

    public int FreAns { get; set; }

    public int FreFullLession { get; set; }

    public bool? UpdateFb { get; set; }

    public string? Comment { get; set; }

    public virtual Classroome Class { get; set; } = null!;

    public virtual Frequency FreAnsNavigation { get; set; } = null!;

    public virtual Frequency FreFullLessionNavigation { get; set; } = null!;

    public virtual Frequency FreOnTimeNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
