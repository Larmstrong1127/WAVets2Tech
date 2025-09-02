using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// Stores students bookmarked by individual employer accounts.
/// </summary>
public partial class BookmarkedStudent
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// References the employer account that bookmarked this student account.
    /// </summary>
    public int EmployerId { get; set; }

    /// <summary>
    /// References the student profile (account) that was bookmarked by this employer.
    /// </summary>
    public int StudentId { get; set; }

    public virtual Employer Employer { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
