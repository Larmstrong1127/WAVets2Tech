using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// A table containing information on employer accounts.
/// </summary>
public partial class Employer
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The real first name of the company worker behind this account.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The real last name for the company worker behind this account.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The contact email address that should be used for anything related to the Vets2Tech program.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Used to store the password hash (not the password itself) of the account. May or may not be used, depending on how we choose to do authentication.
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// The contact phone number that should be used for anything related to the Vets2Tech program.
    /// </summary>
    public int? Phone { get; set; }

    /// <summary>
    /// The mailbox (company or personal) address that should be used for anything related to the Vets2Tech program.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Can be filled with whatever the employer wants. Recommended that they briefly describe themselves, and also provide any information that might be useful to prospective employees who might contact them. Max 4000 characters.
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// References the company this employer works for.
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Optional field intended to store a picture of the employer account owner, if one is provided.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!
    /// </summary>
    public byte[]? ProfilePicture { get; set; }

    public virtual ICollection<BookmarkedStudent> BookmarkedStudents { get; } = new List<BookmarkedStudent>();

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
