using System;
using System.Collections.Generic;

namespace MortgageMoniteringSystem.Models;

public partial class Register
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? UserPassword { get; set; }

    public string Access { get; set; } = null!;
}
