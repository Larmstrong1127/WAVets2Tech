using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// Stores jobs bookedmarked by individual student accounts.
/// </summary>
public partial class BookmarkedJob
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// References the student account that has this job bookmarked.
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// References the specific job listing that the student bookmarked.
    /// </summary>
    public int JobId { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
