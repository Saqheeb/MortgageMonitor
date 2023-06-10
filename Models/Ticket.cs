using System;
using System.Collections.Generic;

namespace MortgageMoniteringSystem.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    //public int? Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? TicketDate { get; set; }

    public string? Response { get; set; }
}
