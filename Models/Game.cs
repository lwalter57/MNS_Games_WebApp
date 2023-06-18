using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class Game
{
    public int Id { get; set; }

    public DateTime StartDatetime { get; set; }

    public DateTime? EndDatetime { get; set; }

    public int QuizId { get; set; }

    public int AppUserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    public virtual ICollection<Obtain> Obtains { get; set; } = new List<Obtain>();

    public virtual Quiz Quiz { get; set; } = null!;
}
