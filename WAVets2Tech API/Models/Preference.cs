using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// IMPORTANT: Read the description of the column &quot;account_type.&quot; References to this table in code must ALWAYS account for the value of &quot;account_type&quot; to prevent the preferences from a different account from being used by accident.
/// 
/// Stores the personal preferences/settings of an an Admin, Employer, or Student account. More columns are planned to be added over time.
/// </summary>
public partial class Preference
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// A varchar functioning as an enumerable variable, with 3 different types: &quot;Student&quot; &quot;Employer&quot; and &quot;Admin&quot;
    /// </summary>
    public string AccountType { get; set; } = null!;

    /// <summary>
    /// Serves as a foreign key to 3 tables (Student, Employer, and Admin) depending on the value of &quot;account_type.&quot; Has minimal constraints to prevent issues. Does NOT change or disappear if the corresponding account is created, to prevent issues.
    /// </summary>
    public int AccountId { get; set; }

    public virtual Admin Account { get; set; } = null!;

    public virtual Student Account1 { get; set; } = null!;

    public virtual Employer AccountNavigation { get; set; } = null!;
}
