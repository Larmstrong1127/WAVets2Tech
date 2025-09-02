using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// A table containing all the details on job postings.
/// </summary>
public partial class Job
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string JobTitle { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string CompanyName { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string LevelOrSalaryRange { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string HrContact { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? FieldSupervisor { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? ExternalPostingUrl { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string Location { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? JobCategory { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string JobCode { get; set; } = null!;

    /// <summary>
    /// 0 for no, 1 for yes
    /// </summary>
    public bool TravelRequired { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string PositionType { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public DateTime DatePosted { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public DateTime PostingExpires { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string HrRecruiterContact { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string CompanyContact { get; set; } = null!;

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? DescriptionSummary { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? DescriptionDuties { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? DescriptionRequirements { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? DescriptionBenefits { get; set; }

    /// <summary>
    /// To be filled out by those working for the company, at their discretion.
    /// </summary>
    public string? DescriptionNotes { get; set; }

    /// <summary>
    /// The employer account that created this job listing.
    /// </summary>
    public int EmployerId { get; set; }

    /// <summary>
    /// The company that this job listing corresponds to.
    /// </summary>
    public int CompanyId { get; set; }

    public virtual ICollection<BookmarkedJob> BookmarkedJobs { get; } = new List<BookmarkedJob>();

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual Employer Employer { get; set; } = null!;
}
