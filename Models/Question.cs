using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Question
{
    public int Id { get; set; }

    public string LabelQuestion { get; set; } = null!;

    public TimeSpan? Duration { get; set; }

    public int QuizId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Obtain> Obtains { get; set; } = new List<Obtain>();

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual ICollection<Answer> AnswersNavigation { get; set; } = new List<Answer>();
}
