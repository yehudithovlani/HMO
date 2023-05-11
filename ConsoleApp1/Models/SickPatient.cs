using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class SickPatient
{
    public string PersonId { get; set; } = null!;

    public DateTime? PositiveResult { get; set; }

    public DateTime? Recuperation { get; set; }
}
