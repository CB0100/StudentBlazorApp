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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CBPC-BATHAM\\SQLEXPRESS;Initial Catalog=Dummy;Integrated Security=True;Trust Server Certificate=True");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}