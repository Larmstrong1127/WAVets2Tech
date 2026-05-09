using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// Describes work experience a student has from a past employer. Multiple entires in this table can be linked to a single student. The column &quot;date_range_end&quot; is nullable, just in case they&apos;re still working for that employer.
/// </summary>
public partial class Experience
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The student this work experience record is tied to.
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Does NOT reference an employer account, or a company record. Rather, this is just the NAME of the company they worked for.
    /// </summary>
    public string EmployerCompany { get; set; } = null!;

    /// <summary>
    /// The date (exact or approximate) they started working for the company.
    /// </summary>
    public DateTime DateRangeStart { get; set; }

    /// <summary>
    /// The date (exact or approximate) they stopped working for the company. Can be left blank if they&apos;re currently still employed.
    /// </summary>
    public DateTime? DateRangeEnd { get; set; }

    /// <summary>
    /// The address of the building they worked in - or, if the work was remote, the address of the company&apos;s main building instead.
    /// </summary>
    public string Location { get; set; } = null!;

    /// <summary>
    /// The title of the position they worked in.
    /// </summary>
    public string JobTitle { get; set; } = null!;

    /// <summary>
    /// A brief description of the work performed - although optional, it&apos;s very important that this be filled out, as a job title may not be sufficient to explain what the job was!
    /// </summary>
    public string? JobDescription { get; set; }

    public virtual Student Student { get; set; } = null!;
}
