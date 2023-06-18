using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public string QuizName { get; set; } = null!;

    public TimeSpan? Duration { get; set; }

    public int ThemeId { get; set; }

    public int AppUserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Registrate> Registrates { get; set; } = new List<Registrate>();

    public virtual Theme Theme { get; set; } = null!;

    public virtual ICollection<Badge> Badges { get; set; } = new List<Badge>();
}
