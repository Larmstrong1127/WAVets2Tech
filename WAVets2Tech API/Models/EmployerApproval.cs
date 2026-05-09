using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

public partial class EmployerApproval
{
    public int InternalId { get; set; }

    public string EmployerFirstname { get; set; } = null!;

    public string EmployerLastname { get; set; } = null!;

    public string EmployerEmail { get; set; } = null!;

    public string EmployerPassword { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanyEmail { get; set; } = null!;

    public int CompanyId { get; set; }
}
