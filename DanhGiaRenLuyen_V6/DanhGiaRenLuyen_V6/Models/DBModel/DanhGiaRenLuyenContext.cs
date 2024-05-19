using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DanhGiaRenLuyen_V6.Models.DBModel;

public partial class DanhGiaRenLuyenContext : DbContext
{
    public DanhGiaRenLuyenContext()
    {
    }

    public DanhGiaRenLuyenContext(DbContextOptions<DanhGiaRenLuyenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountAdmin> AccountAdmins { get; set; }

    public virtual DbSet<AccountLecturer> AccountLecturers { get; set; }

    public virtual DbSet<AccountStudent> AccountStudents { get; set; }

    public virtual DbSet<AnswerList> AnswerLists { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassAnswer> ClassAnswers { get; set; }

    public virtual DbSet<Classify> Classifies { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<GroupQuestion> GroupQuestions { get; set; }

    public virtual DbSet<Lecturers> Lecturers { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<QuestionHisory> QuestionHisories { get; set; }

    public virtual DbSet<QuestionList> QuestionLists { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelfAnswer> SelfAnswers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Students> Students { get; set; }

    public virtual DbSet<SumaryOfPoint> SumaryOfPoints { get; set; }

    public virtual DbSet<TypeQuestion> TypeQuestions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQL2014;Database=DanhGiaRenLuyen;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountA__3214EC076CDA8442");

            entity.ToTable("AccountAdmin");

            entity.HasIndex(e => e.UserName, "UQ__AccountA__C9F28456BECE7B53").IsUnique();

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.AccountAdmins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__AccountAd__RoleI__2D27B809");
        });

        modelBuilder.Entity<AccountLecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountL__3214EC07E558260A");

            entity.ToTable("AccountLecturer");

            entity.HasIndex(e => e.UserName, "UQ__AccountL__C9F2845618B3AF55").IsUnique();

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LecturerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Lecturer).WithMany(p => p.AccountLecturers)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("FK__AccountLe__Lectu__276EDEB3");
        });

        modelBuilder.Entity<AccountStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountS__3214EC075374E772");

            entity.ToTable("AccountStudent");

            entity.HasIndex(e => e.UserName, "UQ__AccountS__C9F284566ADC68D4").IsUnique();

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.AccountStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__AccountSt__Stude__239E4DCF");
        });

        modelBuilder.Entity<AnswerList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnswerLi__3214EC0720DB2538");

            entity.ToTable("AnswerList");

            entity.Property(e => e.ContentAnswer).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Question).WithMany(p => p.AnswerLists)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__AnswerLis__Quest__398D8EEE");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC0700ED5001");

            entity.ToTable("Class");

            entity.HasIndex(e => e.Name, "UQ__Class__737584F6EB15B35E").IsUnique();

            entity.Property(e => e.CourseId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Class__CourseId__15502E78");

            entity.HasOne(d => d.Department).WithMany(p => p.Classes)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Class__Departmen__164452B1");
        });

        modelBuilder.Entity<ClassAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassAns__3214EC076D270435");

            entity.ToTable("ClassAnswer");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__ClassAnsw__Answe__45F365D3");

            entity.HasOne(d => d.Semester).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__ClassAnsw__Semes__46E78A0C");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__ClassAnsw__Stude__44FF419A");
        });

        modelBuilder.Entity<Classify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classify__3214EC078B35797A");

            entity.ToTable("Classify");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC0720818BA1");

            entity.ToTable("Course");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC073BC6C09C");

            entity.ToTable("Department");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupQue__3214EC074F4A5936");

            entity.ToTable("GroupQuestion");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Lecturers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturer__3214EC078642E5B8");

            entity.ToTable("Lecturer");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(20);

            entity.HasOne(d => d.Department).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Lecturer__Depart__1ED998B2");

            entity.HasOne(d => d.Position).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Lecturer__Positi__1FCDBCEB");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC0751DFB5FB");

            entity.ToTable("Position");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<QuestionHisory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07E56C3820");

            entity.ToTable("QuestionHisory");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionHisories)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__QuestionH__Quest__3C69FB99");

            entity.HasOne(d => d.Semester).WithMany(p => p.QuestionHisories)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__QuestionH__Semes__3D5E1FD2");
        });

        modelBuilder.Entity<QuestionList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC078B8AED1E");

            entity.ToTable("QuestionList");

            entity.Property(e => e.ContentQuestion).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.GroupQuestion).WithMany(p => p.QuestionLists)
                .HasForeignKey(d => d.GroupQuestionId)
                .HasConstraintName("FK__QuestionL__Group__36B12243");

            entity.HasOne(d => d.TypeQuestion).WithMany(p => p.QuestionLists)
                .HasForeignKey(d => d.TypeQuestionId)
                .HasConstraintName("FK__QuestionL__TypeQ__35BCFE0A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07FC63390C");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<SelfAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SelfAnsw__3214EC07AD42F139");

            entity.ToTable("SelfAnswer");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__SelfAnswe__Answe__412EB0B6");

            entity.HasOne(d => d.Semester).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__SelfAnswe__Semes__4222D4EF");

            entity.HasOne(d => d.Student).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SelfAnswe__Stude__403A8C7D");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC074172445B");

            entity.ToTable("Semester");

            entity.Property(e => e.DateEndClass).HasColumnType("datetime");
            entity.Property(e => e.DateEndLecturer).HasColumnType("datetime");
            entity.Property(e => e.DateEndStudent).HasColumnType("datetime");
            entity.Property(e => e.DateOpenStudent).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Students>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07E1DE6869");

            entity.ToTable("Student");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__1B0907CE");

            entity.HasOne(d => d.Position).WithMany(p => p.Students)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Student__Positio__1BFD2C07");
        });

        modelBuilder.Entity<SumaryOfPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SumaryOf__3214EC07131982E2");

            entity.ToTable("SumaryOfPoint");

            entity.Property(e => e.Classify).HasMaxLength(50);
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserLecturer)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Class).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__SumaryOfP__Class__4BAC3F29");

            entity.HasOne(d => d.Semester).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__SumaryOfP__Semes__4AB81AF0");

            entity.HasOne(d => d.Student).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SumaryOfP__Stude__49C3F6B7");
        });

        modelBuilder.Entity<TypeQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeQues__3214EC07D0D53B7A");

            entity.ToTable("TypeQuestion");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
