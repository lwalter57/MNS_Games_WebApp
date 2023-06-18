using System;
using System.Collections.Generic;

namespace MNS_Games_WebApplication.Models;

public partial class AppUser
{
    public int Id { get; set; }

    public string LoginNickname { get; set; } = null!;

    public string LoginPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool IsAdmin { get; set; }

    public string? StreetNumber { get; set; }

    public string? StreetName { get; set; }

    public string? Zipcode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public virtual ICollection<Registrate> Registrates { get; set; } = new List<Registrate>();
}
