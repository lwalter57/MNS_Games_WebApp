using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Badge
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Descript { get; set; }

    public string? ObtainingConditions { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
