using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class MessagesChat
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int TeacherId { get; set; }

    public string? MessageContent { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Sender { get; set; }

    public bool? IsRead { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
