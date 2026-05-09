using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// Will be used to store information on the companies each employer belongs to. Multiple employers can be associated with 1 company, and the same applies to jobs.
/// </summary>
public partial class Company
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The formal, full name of the company.
    /// </summary>
    public string CompanyName { get; set; } = null!;

    /// <summary>
    /// The email address to contact for inquiries relating to jobs/recruitment.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// The phone number to contact for inquiries relating to jobs/recruitment.
    /// </summary>
    public int Phone { get; set; }

    /// <summary>
    /// The physical address of the company building - either the main building, or the building that jobs are being offered for. Can also be left blank if that information isn&apos;t relevant.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// A field for a company to briefly describe what they are all about, and what kinds of workers they are looking for. Max 4000 characters.
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// Optional field intended to store a logo of the company. Can theoretically store a picture of something else, though.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!
    /// </summary>
    public byte[]? LogoImage { get; set; }

    /// <summary>
    /// Optional field intended to store a picture of the company&apos;s main building, if all their jobs opportunities will be based in this building.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!
    /// </summary>
    public byte[]? BuildingImage { get; set; }

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual ICollection<Employer> Employers { get; } = new List<Employer>();

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
