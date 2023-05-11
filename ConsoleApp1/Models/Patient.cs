using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Patient
{
    public string PersonId { get; set; } = null!;

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? HouseNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? CellPhone { get; set; }

    public string? HomePhone { get; set; }
}
