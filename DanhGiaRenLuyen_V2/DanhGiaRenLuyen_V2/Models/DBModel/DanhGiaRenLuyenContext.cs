using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

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

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassAnswer> ClassAnswers { get; set; }

    public virtual DbSet<Classify> Classifies { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<GroupQuestion> GroupQuestions { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelfAnswer> SelfAnswers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<SumaryOfPoint> SumaryOfPoints { get; set; }

    public virtual DbSet<TypeQuestion> TypeQuestions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQL2014;Database=DanhGiaRenLuyen;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountA__3214EC070C52CB1A");

            entity.ToTable("AccountAdmin");

            entity.HasIndex(e => e.UserName, "UQ__AccountA__C9F2845659755AAA").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__AccountL__3214EC07CD36C280");

            entity.ToTable("AccountLecturer");

            entity.HasIndex(e => e.UserName, "UQ__AccountL__C9F28456074898DA").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__AccountS__3214EC07D419A1F3");

            entity.ToTable("AccountStudent");

            entity.HasIndex(e => e.UserName, "UQ__AccountS__C9F284560FCC8169").IsUnique();

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

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC072B1A3722");

            entity.ToTable("Answer");

            entity.Property(e => e.Answer1)
                .HasMaxLength(500)
                .HasColumnName("Answer");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__3A81B327");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC0780F158FB");

            entity.ToTable("Class");

            entity.HasIndex(e => e.Name, "UQ__Class__737584F62A09C0BF").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__ClassAns__3214EC07A59093C3");

            entity.ToTable("ClassAnswer");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__ClassAnsw__Answe__4222D4EF");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__ClassAnsw__Stude__412EB0B6");
        });

        modelBuilder.Entity<Classify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classify__3214EC079EB60E84");

            entity.ToTable("Classify");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC07ED9FCDF2");

            entity.ToTable("Course");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Course1)
                .HasMaxLength(50)
                .HasColumnName("Course");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0721AD8C69");

            entity.ToTable("Department");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupQue__3214EC07B34552C9");

            entity.ToTable("GroupQuestion");

            entity.Property(e => e.GroupQuestion1)
                .HasMaxLength(255)
                .HasColumnName("GroupQuestion");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturer__3214EC07F78EBFD1");

            entity.ToTable("Lecturer");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PositionId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Department).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Lecturer__Depart__1ED998B2");

            entity.HasOne(d => d.Position).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Lecturer__Positi__1FCDBCEB");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07699B1118");

            entity.ToTable("Position");

            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC078B4828FB");

            entity.ToTable("Question");

            entity.Property(e => e.Question1)
                .HasMaxLength(500)
                .HasColumnName("Question");

            entity.HasOne(d => d.GroupQuestion).WithMany(p => p.Questions)
                .HasForeignKey(d => d.GroupQuestionId)
                .HasConstraintName("FK__Question__GroupQ__37A5467C");

            entity.HasOne(d => d.Semester).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Question__Semest__36B12243");

            entity.HasOne(d => d.TypeQuestion).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TypeQuestionId)
                .HasConstraintName("FK__Question__TypeQu__35BCFE0A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07489B74EA");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<SelfAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SelfAnsw__3214EC0780F0DBD0");

            entity.ToTable("SelfAnswer");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__SelfAnswe__Answe__3E52440B");

            entity.HasOne(d => d.Student).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SelfAnswe__Stude__3D5E1FD2");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC07AF8CF1C5");

            entity.ToTable("Semester");

            entity.Property(e => e.DateEndClass).HasColumnType("datetime");
            entity.Property(e => e.DateEndLecturer).HasColumnType("datetime");
            entity.Property(e => e.DateEndStudent).HasColumnType("datetime");
            entity.Property(e => e.DateOpenStudent).HasColumnType("datetime");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Semester1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Semester");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC073156BE88");

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
            entity.Property(e => e.PositionId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__1B0907CE");

            entity.HasOne(d => d.Position).WithMany(p => p.Students)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Student__Positio__1BFD2C07");
        });

        modelBuilder.Entity<SumaryOfPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SumaryOf__3214EC07E0BFECC6");

            entity.ToTable("SumaryOfPoint");

            entity.Property(e => e.Classify).HasMaxLength(50);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Semester).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__SumaryOfP__Semes__45F365D3");

            entity.HasOne(d => d.Student).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SumaryOfP__Stude__44FF419A");
        });

        modelBuilder.Entity<TypeQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeQues__3214EC07EE6C3DD6");

            entity.ToTable("TypeQuestion");

            entity.Property(e => e.TypeQuestion1)
                .HasMaxLength(100)
                .HasColumnName("TypeQuestion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
