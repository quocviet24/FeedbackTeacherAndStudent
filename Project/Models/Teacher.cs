﻿using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public int? NumberExp { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public bool? Gender { get; set; }

    public int? IdAccount { get; set; }

    public virtual ICollection<FeedbacksCurent> FeedbacksCurents { get; set; } = new List<FeedbacksCurent>();

    public virtual Account? IdAccountNavigation { get; set; }

    public virtual ICollection<MessagesChat> MessagesChats { get; set; } = new List<MessagesChat>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
}
