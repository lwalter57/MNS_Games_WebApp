using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Answer
{
    public int Id { get; set; }

    public string LabelAnswer { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public int? Points { get; set; }

    public int QuestionId { get; set; }

    public virtual ICollection<Obtain> Obtains { get; set; } = new List<Obtain>();

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
