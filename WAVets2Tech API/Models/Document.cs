using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// IMPORTANT: Read the description of the column &quot;document_for.&quot; References to this table in code must ALWAYS account for the value of &quot;document_for,&quot; to prevent documents from appearing in unexpected places.
/// 
/// Stores documents related to students, companies, and jobs. Since the column &quot;reference_id&quot; can reference 3 tables, it is treated as a foreign key to all 3, but with minimal constraints, and does not respond to changes to related tables. 
/// </summary>
public partial class Document
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The actual data/file of the document. Will likely be in the form of .docx, .pdf, or other formats frequently used for documents.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the submission forms, to put a restriction so that only reasonable file sizes/formats are allowed!
    /// </summary>
    public byte[] DocumentData { get; set; } = null!;

    /// <summary>
    /// Indicates what kind of document this is mean to be.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// A detailed description explaining (in greater detail) the document&apos;s contents, the purpose for which it was uploaded, or any context that may be important. Max 4000 characters.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// A varchar functioning as an enumerable variable, with 3 different types: &quot;Student&quot; &quot;Company&quot; and &quot;Job&quot;
    /// </summary>
    public string DocumentFor { get; set; } = null!;

    /// <summary>
    /// Serves as a foreign key to 3 tables (Student, Company, and Job) depending on the value of &quot;document_for.&quot; Has minimal constraints to prevent issues.
    /// </summary>
    public int ReferenceId { get; set; }

    public virtual Company Reference { get; set; } = null!;

    public virtual Student Reference1 { get; set; } = null!;

    public virtual Job ReferenceNavigation { get; set; } = null!;
}
