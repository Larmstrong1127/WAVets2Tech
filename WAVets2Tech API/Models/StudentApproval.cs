using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

public partial class StudentApproval
{
    public int InternalId { get; set; }

    public string StudentFirstname { get; set; } = null!;

    public string StudentLastname { get; set; } = null!;

    public string StudentEmail { get; set; } = null!;

    public string StudentPassword { get; set; } = null!;
}
