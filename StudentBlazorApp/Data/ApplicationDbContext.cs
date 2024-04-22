using Microsoft.EntityFrameworkCore;

namespace StudentBlazorApp.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<Hobby2StudentMapp> Hobby2StudentMapps { get; set; }
    public virtual DbSet<Course2Student> Course2StudentMapps { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TblQualification> TblQualifications { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Batch> Batches { get; set; }
    public virtual DbSet<Specification> Specifications { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryId).HasColumnName("CountryId");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.StateId).HasColumnName("StateId");
            entity.Property(e => e.CountryId).HasColumnName("CountryId");
        });

        modelBuilder.Entity<TblQualification>(entity =>
        {
            entity.HasKey(e => e.StdQlfId);

            entity.ToTable("TblQualifications");

            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_TblStudents_1");

            entity.ToTable("TblStudents");

            entity.HasIndex(e => e.RegistrationId, "IX_TblStudents_RegistrationId").IsUnique();

            entity.HasIndex(e => new { e.EmailAddress, e.PhoneNumber }, "UQ_EmailPhone").IsUnique();

            entity.Property(e => e.Dob).HasColumnName("Dob");
            entity.Property(e => e.RegistrationId).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Course>()
        .Property(c => c.Fees)
        .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Course2Student>()
            .Property(c => c.TotalPaid)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Course2Student>()
            .Property(c => c.tax)
            .HasColumnType("decimal(18,2)");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}