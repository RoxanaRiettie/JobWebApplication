using JobWebApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobWebApplication.Infrastructure.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public DbSet<JobPosition> JobPositions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C008228");

                entity.ToTable("JOB_POSTINGS");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");
                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("BUDGET");
                entity.Property(e => e.ClosingDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSING_DATE");
                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTMENT_ID");
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");
                entity.Property(e => e.RecruiterId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECRUITER_ID");
                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'draft' ")
                    .HasColumnName("STATUS");
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
