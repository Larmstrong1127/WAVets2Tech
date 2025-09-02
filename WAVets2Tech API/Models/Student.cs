using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// A table containing information on student accounts.
/// </summary>
public partial class Student
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The real first name of the student who created this account.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The real last name of the student who created this account.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The email address used for contacting the student. School email is probably preferred, though personal email can also work.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Used to store the password hash (not the password itself) of the account. May or may not be used, depending on how we choose to do authentication.
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// The personal phone number that can be used for contacting the student.
    /// </summary>
    public int? Phone { get; set; }

    /// <summary>
    /// The physical/home address of the student, or their mailbox address.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// A URL for the student&apos;s LinkedIn profile.
    /// </summary>
    public string? Linkedin { get; set; }

    /// <summary>
    /// A space for students to describe themselves, and make themselves more appealing to employers. Express yourself! Max 4000 characters.
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// A space for students to describe their interests, passion, or persoanlity. Express yourself! Max 4000 characters.
    /// </summary>
    public string? Interests { get; set; }

    /// <summary>
    /// A space for students to describe what additional training or qualifications they may have, so it&apos;s easily visible to employers. Max 4000 characters.
    /// </summary>
    public string? AdditionalTraining { get; set; }

    /// <summary>
    /// Optional field intended to store a picture of the student themselves, if one is provided.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!
    /// </summary>
    public byte[]? ProfilePicture { get; set; }

    public virtual ICollection<BookmarkedJob> BookmarkedJobs { get; } = new List<BookmarkedJob>();

    public virtual ICollection<BookmarkedStudent> BookmarkedStudents { get; } = new List<BookmarkedStudent>();

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual MilitaryBackground? MilitaryBackground { get; set; }
}
