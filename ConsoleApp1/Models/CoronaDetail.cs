using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class CoronaDetail
{
    public string PersonId { get; set; } = null!;

    public DateTime? GettingVaccinated1 { get; set; }

    public string? VaccineManufacturer1 { get; set; }

    public DateTime? GettingVaccinated2 { get; set; }

    public string? VaccineManufacturer2 { get; set; }

    public DateTime? GettingVaccinated3 { get; set; }

    public string? VaccineManufacturer3 { get; set; }

    public DateTime? GettingVaccinated4 { get; set; }

    public string? VaccineManufacturer4 { get; set; }
}
