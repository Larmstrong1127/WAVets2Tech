using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// Details a student&apos;s education at a particular school. Multiple schools can be linked to a single student&apos;s account.  If the student_id value is 0, that probably means it isn&apos;t connected to a student for some reason.
/// </summary>
public partial class Education
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The student account that this education record/information is tied to.
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// The school the student attended.
    /// </summary>
    public string School { get; set; } = null!;

    /// <summary>
    /// The year the student graduated from this school.
    /// </summary>
    public DateTime GraduationYear { get; set; }

    /// <summary>
    /// The physical address of the attended school.
    /// </summary>
    public string Location { get; set; } = null!;

    /// <summary>
    /// The degree the student graduated with.
    /// </summary>
    public string Degree { get; set; } = null!;

    /// <summary>
    /// Field for any additional context - honors, circumstances, programs, clubs, or anything else that&apos;s relevant. Max 4000 characters.
    /// </summary>
    public string? About { get; set; }

    public virtual Student Student { get; set; } = null!;
}
