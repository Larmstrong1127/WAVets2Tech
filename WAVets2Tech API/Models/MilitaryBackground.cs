using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// A table containing the details on a specific student&apos;s military background. Tied to a student record but stored separately so the student table does not become bloated.
/// </summary>
public partial class MilitaryBackground
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The student account this military background record corresponds to.
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// The rank the student had in the military.
    /// </summary>
    public string Rank { get; set; } = null!;

    /// <summary>
    /// The specific job/responsibility the student had during service.
    /// </summary>
    public string JobSpecialty { get; set; } = null!;

    /// <summary>
    /// The specific branch of the military served.
    /// </summary>
    public string BranchOfService { get; set; } = null!;

    /// <summary>
    /// The student&apos;s level of security clearance.
    /// </summary>
    public string SecurityClearance { get; set; } = null!;

    /// <summary>
    /// Note that this is a DATE, rather than a string/varchar!
    /// </summary>
    public DateTime AvailabilityDate { get; set; }

    /// <summary>
    /// Note that this is a DATE, rather than a string/varchar!
    /// </summary>
    public DateTime? Expires { get; set; }

    /// <summary>
    /// A space to provide a detailed description of whatever information may be relevant. I don&apos;t know 
    /// </summary>
    public string? About { get; set; }

    public virtual Student Student { get; set; } = null!;
}
