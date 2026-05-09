using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WAVets2Tech_API.Models;

public partial class Wavets2TechContext : DbContext
{
    public Wavets2TechContext()
    {
    }

    public Wavets2TechContext(DbContextOptions<Wavets2TechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BookmarkedJob> BookmarkedJobs { get; set; }

    public virtual DbSet<BookmarkedStudent> BookmarkedStudents { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<EmployerApproval> EmployerApprovals { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<MilitaryBackground> MilitaryBackgrounds { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentApproval> StudentApprovals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=WAVets2Tech; Integrated Security = True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Admin");

            entity.Property(e => e.InternalId).HasColumnName("internal_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<BookmarkedJob>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Bookmarked_Job", tb => tb.HasComment("Stores jobs bookedmarked by individual student accounts."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.JobId)
                .HasComment("References the specific job listing that the student bookmarked.")
                .HasColumnName("job_id");
            entity.Property(e => e.StudentId)
                .HasComment("References the student account that has this job bookmarked.")
                .HasColumnName("student_id");

            entity.HasOne(d => d.Job).WithMany(p => p.BookmarkedJobs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookmark_References_Job");

            entity.HasOne(d => d.Student).WithMany(p => p.BookmarkedJobs)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookmark_Belongs_To_Student");
        });

        modelBuilder.Entity<BookmarkedStudent>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Bookmarked_Student", tb => tb.HasComment("Stores students bookmarked by individual employer accounts."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.EmployerId)
                .HasComment("References the employer account that bookmarked this student account.")
                .HasColumnName("employer_id");
            entity.Property(e => e.StudentId)
                .HasComment("References the student profile (account) that was bookmarked by this employer.")
                .HasColumnName("student_id");

            entity.HasOne(d => d.Employer).WithMany(p => p.BookmarkedStudents)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookmark_Belongs_To_Employer");

            entity.HasOne(d => d.Student).WithMany(p => p.BookmarkedStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookmark_References_Student");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Company", tb => tb.HasComment("Will be used to store information on the companies each employer belongs to. Multiple employers can be associated with 1 company, and the same applies to jobs."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.About)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A field for a company to briefly describe what they are all about, and what kinds of workers they are looking for. Max 4000 characters.")
                .HasColumnName("about");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The physical address of the company building - either the main building, or the building that jobs are being offered for. Can also be left blank if that information isn't relevant.")
                .HasColumnName("address");
            entity.Property(e => e.BuildingImage)
                .HasComment("Optional field intended to store a picture of the company's main building, if all their jobs opportunities will be based in this building.\r\n\r\nIMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!")
                .HasColumnName("building_image");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The formal, full name of the company.")
                .HasColumnName("company_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The email address to contact for inquiries relating to jobs/recruitment.")
                .HasColumnName("email");
            entity.Property(e => e.LogoImage)
                .HasComment("Optional field intended to store a logo of the company. Can theoretically store a picture of something else, though.\r\n\r\nIMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!")
                .HasColumnName("logo_image");
            entity.Property(e => e.Phone)
                .HasComment("The phone number to contact for inquiries relating to jobs/recruitment.")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Document", tb => tb.HasComment("IMPORTANT: Read the description of the column \"document_for.\" References to this table in code must ALWAYS account for the value of \"document_for,\" to prevent documents from appearing in unexpected places.\r\n\r\nStores documents related to students, companies, and jobs. Since the column \"reference_id\" can reference 3 tables, it is treated as a foreign key to all 3, but with minimal constraints, and does not respond to changes to related tables. "));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A detailed description explaining (in greater detail) the document's contents, the purpose for which it was uploaded, or any context that may be important. Max 4000 characters.")
                .HasColumnName("description");
            entity.Property(e => e.DocumentData)
                .HasComment("The actual data/file of the document. Will likely be in the form of .docx, .pdf, or other formats frequently used for documents.\r\n\r\nIMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the submission forms, to put a restriction so that only reasonable file sizes/formats are allowed!")
                .HasColumnName("document_data");
            entity.Property(e => e.DocumentFor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('None')")
                .HasComment("A varchar functioning as an enumerable variable, with 3 different types: \"Student\" \"Company\" and \"Job\"")
                .HasColumnName("document_for");
            entity.Property(e => e.ReferenceId)
                .HasComment("Serves as a foreign key to 3 tables (Student, Company, and Job) depending on the value of \"document_for.\" Has minimal constraints to prevent issues.")
                .HasColumnName("reference_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Indicates what kind of document this is mean to be.")
                .HasColumnName("title");

            entity.HasOne(d => d.Reference).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Document_To_Company_FK");

            entity.HasOne(d => d.ReferenceNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Document_To_Job_FK");

            entity.HasOne(d => d.Reference1).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Document_To_Student_FK");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Education", tb => tb.HasComment("Details a student's education at a particular school. Multiple schools can be linked to a single student's account.  If the student_id value is 0, that probably means it isn't connected to a student for some reason."));

            entity.Property(e => e.InternalId)
                .ValueGeneratedNever()
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.About)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("Field for any additional context - honors, circumstances, programs, clubs, or anything else that's relevant. Max 4000 characters.")
                .HasColumnName("about");
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The degree the student graduated with.")
                .HasColumnName("degree");
            entity.Property(e => e.GraduationYear)
                .HasComment("The year the student graduated from this school.")
                .HasColumnType("date")
                .HasColumnName("graduation_year");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The physical address of the attended school.")
                .HasColumnName("location");
            entity.Property(e => e.School)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The school the student attended.")
                .HasColumnName("school");
            entity.Property(e => e.StudentId)
                .HasComment("The student account that this education record/information is tied to.")
                .HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Educations)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Education_To_Student_FK");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Employer", tb => tb.HasComment("A table containing information on employer accounts."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.About)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("Can be filled with whatever the employer wants. Recommended that they briefly describe themselves, and also provide any information that might be useful to prospective employees who might contact them. Max 4000 characters.")
                .HasColumnName("about");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The mailbox (company or personal) address that should be used for anything related to the Vets2Tech program.")
                .HasColumnName("address");
            entity.Property(e => e.CompanyId)
                .HasComment("References the company this employer works for.")
                .HasColumnName("company_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The contact email address that should be used for anything related to the Vets2Tech program.")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The real first name of the company worker behind this account.")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The real last name for the company worker behind this account.")
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Used to store the password hash (not the password itself) of the account. May or may not be used, depending on how we choose to do authentication.")
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasComment("The contact phone number that should be used for anything related to the Vets2Tech program.")
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePicture)
                .HasComment("Optional field intended to store a picture of the employer account owner, if one is provided.\r\n\r\nIMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!")
                .HasColumnName("profile_picture");

            entity.HasOne(d => d.Company).WithMany(p => p.Employers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employer_To_Company_FK");
        });

        modelBuilder.Entity<EmployerApproval>(entity =>
        {
            entity.HasKey(e => e.InternalId).HasName("PK__Employer__1C4927D2DF33EBAF");

            entity.ToTable("EmployerApproval");

            entity.Property(e => e.InternalId).HasColumnName("internal_id");
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_email");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.EmployerEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employer_email");
            entity.Property(e => e.EmployerFirstname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employer_firstname");
            entity.Property(e => e.EmployerLastname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employer_lastname");
            entity.Property(e => e.EmployerPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employer_password");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Experience", tb => tb.HasComment("Describes work experience a student has from a past employer. Multiple entires in this table can be linked to a single student. The column \"date_range_end\" is nullable, just in case they're still working for that employer."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.DateRangeEnd)
                .HasComment("The date (exact or approximate) they stopped working for the company. Can be left blank if they're currently still employed.")
                .HasColumnType("date")
                .HasColumnName("date_range_end");
            entity.Property(e => e.DateRangeStart)
                .HasComment("The date (exact or approximate) they started working for the company.")
                .HasColumnType("date")
                .HasColumnName("date_range_start");
            entity.Property(e => e.EmployerCompany)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Does NOT reference an employer account, or a company record. Rather, this is just the NAME of the company they worked for.")
                .HasColumnName("employer_company");
            entity.Property(e => e.JobDescription)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A brief description of the work performed - although optional, it's very important that this be filled out, as a job title may not be sufficient to explain what the job was!")
                .HasColumnName("job_description");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The title of the position they worked in.")
                .HasColumnName("job_title");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The address of the building they worked in - or, if the work was remote, the address of the company's main building instead.")
                .HasColumnName("location");
            entity.Property(e => e.StudentId)
                .HasComment("The student this work experience record is tied to.")
                .HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Experience_To_Student_FK");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Job", tb => tb.HasComment("A table containing all the details on job postings."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.CompanyContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("company_contact");
            entity.Property(e => e.CompanyId)
                .HasComment("The company that this job listing corresponds to.")
                .HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("company_name");
            entity.Property(e => e.DatePosted)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnType("date")
                .HasColumnName("date_posted");
            entity.Property(e => e.DescriptionBenefits)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("description_benefits");
            entity.Property(e => e.DescriptionDuties)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("description_duties");
            entity.Property(e => e.DescriptionNotes)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("description_notes");
            entity.Property(e => e.DescriptionRequirements)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("description_requirements");
            entity.Property(e => e.DescriptionSummary)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("description_summary");
            entity.Property(e => e.EmployerId)
                .HasComment("The employer account that created this job listing.")
                .HasColumnName("employer_id");
            entity.Property(e => e.ExternalPostingUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("external_posting_url");
            entity.Property(e => e.FieldSupervisor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("field_supervisor");
            entity.Property(e => e.HrContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("hr_contact");
            entity.Property(e => e.HrRecruiterContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("hr_recruiter_contact");
            entity.Property(e => e.JobCategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("job_category");
            entity.Property(e => e.JobCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("job_code");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("job_title");
            entity.Property(e => e.LevelOrSalaryRange)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("level_or_salary_range");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("location");
            entity.Property(e => e.PositionType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnName("position_type");
            entity.Property(e => e.PostingExpires)
                .HasComment("To be filled out by those working for the company, at their discretion.")
                .HasColumnType("date")
                .HasColumnName("posting_expires");
            entity.Property(e => e.TravelRequired)
                .HasComment("0 for no, 1 for yes")
                .HasColumnName("travel_required");

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Job_To_Company_FK");

            entity.HasOne(d => d.Employer).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Job_To_Employer_FK");
        });

        modelBuilder.Entity<MilitaryBackground>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Military_Background", tb => tb.HasComment("A table containing the details on a specific student's military background. Tied to a student record but stored separately so the student table does not become bloated."));

            entity.HasIndex(e => e.StudentId, "Military_Background_FK_Unique").IsUnique();

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.About)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A space to provide a detailed description of whatever information may be relevant. I don't know ")
                .HasColumnName("about");
            entity.Property(e => e.AvailabilityDate)
                .HasComment("Note that this is a DATE, rather than a string/varchar!")
                .HasColumnType("date")
                .HasColumnName("availability_date");
            entity.Property(e => e.BranchOfService)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The specific branch of the military served.")
                .HasColumnName("branch_of_service");
            entity.Property(e => e.Expires)
                .HasComment("Note that this is a DATE, rather than a string/varchar!")
                .HasColumnType("date")
                .HasColumnName("expires");
            entity.Property(e => e.JobSpecialty)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The specific job/responsibility the student had during service.")
                .HasColumnName("job_specialty");
            entity.Property(e => e.Rank)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The rank the student had in the military.")
                .HasColumnName("rank");
            entity.Property(e => e.SecurityClearance)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The student's level of security clearance.")
                .HasColumnName("security_clearance");
            entity.Property(e => e.StudentId)
                .HasComment("The student account this military background record corresponds to.")
                .HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithOne(p => p.MilitaryBackground)
                .HasForeignKey<MilitaryBackground>(d => d.StudentId)
                .HasConstraintName("Military_Background_To_Student_FK");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.InternalId);

            entity.ToTable("Student", tb => tb.HasComment("A table containing information on student accounts."));

            entity.Property(e => e.InternalId)
                .HasComment("A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.\r\n\r\nVERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.")
                .HasColumnName("internal_id");
            entity.Property(e => e.About)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A space for students to describe themselves, and make themselves more appealing to employers. Express yourself! Max 4000 characters.")
                .HasColumnName("about");
            entity.Property(e => e.AdditionalTraining)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A space for students to describe what additional training or qualifications they may have, so it's easily visible to employers. Max 4000 characters.")
                .HasColumnName("additional_training");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The physical/home address of the student, or their mailbox address.")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The email address used for contacting the student. School email is probably preferred, though personal email can also work.")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The real first name of the student who created this account.")
                .HasColumnName("first_name");
            entity.Property(e => e.Interests)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasComment("A space for students to describe their interests, passion, or persoanlity. Express yourself! Max 4000 characters.")
                .HasColumnName("interests");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("The real last name of the student who created this account.")
                .HasColumnName("last_name");
            entity.Property(e => e.Linkedin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("A URL for the student's LinkedIn profile.")
                .HasColumnName("linkedin");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Used to store the password hash (not the password itself) of the account. May or may not be used, depending on how we choose to do authentication.")
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasComment("The personal phone number that can be used for contacting the student.")
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePicture)
                .HasComment("Optional field intended to store a picture of the student themselves, if one is provided.\r\n\r\nIMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!")
                .HasColumnName("profile_picture");
        });

        modelBuilder.Entity<StudentApproval>(entity =>
        {
            entity.HasKey(e => e.InternalId).HasName("PK__StudentA__1C4927D265860818");

            entity.ToTable("StudentApproval");

            entity.Property(e => e.InternalId).HasColumnName("internal_id");
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("student_email");
            entity.Property(e => e.StudentFirstname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("student_firstname");
            entity.Property(e => e.StudentLastname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("student_lastname");
            entity.Property(e => e.StudentPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("student_password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
