using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Theme
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
