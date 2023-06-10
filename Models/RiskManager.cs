using System;
using System.Collections.Generic;

namespace MortgageMoniteringSystem.Models;

public partial class RiskManager
{
    public int RiskManagerId { get; set; }

    public string? RiskManagerName { get; set; }

    public string? RiskManagerMail { get; set; }

    public string? RiskManagerPassword { get; set; }

    public string? RiskManagerAccess { get; set; }
}
