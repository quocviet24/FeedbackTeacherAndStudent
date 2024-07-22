using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class ProjectQnaContext : DbContext
{
    public ProjectQnaContext()
    {
    }

    public ProjectQnaContext(DbContextOptions<ProjectQnaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Classroome> Classroomes { get; set; }

    public virtual DbSet<FeedbacksCurent> FeedbacksCurents { get; set; }

    public virtual DbSet<Frequency> Frequencies { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<MessagesChat> MessagesChats { get; set; }

    public virtual DbSet<Mojor> Mojors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClass> StudentClasses { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =ADMIN; database = Project_QNA;uid=sa;pwd=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3214EC07F7F22BFC");

            entity.HasIndex(e => e.Username, "UQ__Accounts__536C85E405DD7D32").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.RoleId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Username).HasMaxLength(30);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Accounts__RoleId__286302EC");
        });

        modelBuilder.Entity<Classroome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classroo__3214EC07CFDCCFF2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassName).HasMaxLength(30);
        });

        modelBuilder.Entity<FeedbacksCurent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC0704272FF3");

            entity.ToTable("FeedbacksCurent");

            entity.HasOne(d => d.Class).WithMany(p => p.FeedbacksCurents)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Class__4222D4EF");

            entity.HasOne(d => d.FreAnsNavigation).WithMany(p => p.FeedbacksCurentFreAnsNavigations)
                .HasForeignKey(d => d.FreAns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__FreAn__440B1D61");

            entity.HasOne(d => d.FreFullLessionNavigation).WithMany(p => p.FeedbacksCurentFreFullLessionNavigations)
                .HasForeignKey(d => d.FreFullLession)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__FreFu__44FF419A");

            entity.HasOne(d => d.FreOnTimeNavigation).WithMany(p => p.FeedbacksCurentFreOnTimeNavigations)
                .HasForeignKey(d => d.FreOnTime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__FreOn__4316F928");

            entity.HasOne(d => d.Student).WithMany(p => p.FeedbacksCurents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Stude__3F466844");

            entity.HasOne(d => d.Subject).WithMany(p => p.FeedbacksCurents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Subje__412EB0B6");

            entity.HasOne(d => d.Teacher).WithMany(p => p.FeedbacksCurents)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Teach__403A8C7D");
        });

        modelBuilder.Entity<Frequency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frequenc__3214EC075F560260");

            entity.ToTable("Frequency");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fre)
                .HasMaxLength(30)
                .HasColumnName("fre");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.SubjectId }).HasName("PK__Marks__87D8A24666F8971E");

            entity.Property(e => e.Fe).HasColumnName("FE");
            entity.Property(e => e.Fer).HasColumnName("FER");
            entity.Property(e => e.Pe).HasColumnName("PE");

            entity.HasOne(d => d.Class).WithMany(p => p.Marks)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marks__ClassId__48CFD27E");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marks__StudentId__47DBAE45");

            entity.HasOne(d => d.Subject).WithMany(p => p.Marks)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marks__SubjectId__49C3F6B7");
        });

        modelBuilder.Entity<MessagesChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC077687DB36");

            entity.ToTable("MessagesChat");

            entity.Property(e => e.MessageContent).HasMaxLength(500);
            entity.Property(e => e.Sender).HasMaxLength(15);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Student).WithMany(p => p.MessagesChats)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MessagesC__Stude__4CA06362");

            entity.HasOne(d => d.Teacher).WithMany(p => p.MessagesChats)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MessagesC__Teach__4D94879B");
        });

        modelBuilder.Entity<Mojor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mojors__3214EC07A08D0DA3");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07B25A9DFA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameRole).HasMaxLength(40);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC075C33527F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("FK__Students__IdAcco__300424B4");

            entity.HasOne(d => d.Mojor).WithMany(p => p.Students)
                .HasForeignKey(d => d.MojorId)
                .HasConstraintName("FK__Students__MojorI__2F10007B");
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.TeacherId }).HasName("PK__StudentC__4B994BBCCC703153");

            entity.ToTable("StudentClass");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Class__38996AB5");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Stude__37A5467C");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Subje__3A81B327");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Teach__398D8EEE");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC071921527B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC0787009D3F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("FK__Teachers__IdAcco__32E0915F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
