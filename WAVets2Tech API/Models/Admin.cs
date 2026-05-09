using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

public partial class Admin
{
    public int InternalId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public int? Phone { get; set; }

    public string? Address { get; set; }
}
