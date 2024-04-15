using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DanhGiaRenLuyen.Models.DBModel;

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

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DanhGiaRenLuyen;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account___3214EC272AF7E1F7");

            entity.ToTable("Account_Admin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid).HasColumnName("ROLEID");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.AccountAdmins)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("FK__Account_A__ROLEI__286302EC");
        });

        modelBuilder.Entity<AccountLecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account___3214EC2759C67EF7");

            entity.ToTable("Account_Lecturer");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<AccountStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account___3214EC2792FFB446");

            entity.ToTable("Account_Student");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC272E31856E");

            entity.ToTable("Answer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Answer1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Answer");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__32E0915F");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC2733670301");

            entity.ToTable("Class");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CourseID");
            entity.Property(e => e.Name)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAME");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Class__CourseID__145C0A3F");
        });

        modelBuilder.Entity<ClassAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassAns__3214EC27C708BD50");

            entity.ToTable("ClassAnswer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Createby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CREATEBY");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__ClassAnsw__Quest__3B75D760");

            entity.HasOne(d => d.Question).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__ClassAnsw__Answe__3C69FB99");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__ClassAnsw__Stude__3A81B327");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC273A8C80D3");

            entity.ToTable("Course");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC27E144B9ED");

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturer__3214EC2722B3F582");

            entity.ToTable("Lecturer");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Name)
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
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC279D923DF0");

            entity.ToTable("Position");

            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC270BD9C1FC");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Question1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Question");

            entity.HasOne(d => d.Semester).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Question__Semest__300424B4");

            entity.HasOne(d => d.TypeQuestion).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TypeQuestionId)
                .HasConstraintName("FK__Question__TypeQu__2F10007B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC274DA7DE92");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<SelfAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SelfAnsw__3214EC270AD967A3");

            entity.ToTable("SelfAnswer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Answer).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__SelfAnswe__Quest__36B12243");

            entity.HasOne(d => d.Question).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__SelfAnswe__Answe__37A5467C");

            entity.HasOne(d => d.Student).WithMany(p => p.SelfAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SelfAnswe__Stude__35BCFE0A");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC279B40CA35");

            entity.ToTable("Semester");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateEndClass).HasColumnType("datetime");
            entity.Property(e => e.DateEndLecturer).HasColumnType("datetime");
            entity.Property(e => e.DateEndStudent).HasColumnType("datetime");
            entity.Property(e => e.DateOpenStudent).HasColumnType("datetime");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
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
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC27258C42C2");

            entity.ToTable("Student");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.CourseId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CourseID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PositionId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PositionID");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__1B0907CE");

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Student__CourseI__1920BF5C");

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Student__Departm__1A14E395");

            entity.HasOne(d => d.Position).WithMany(p => p.Students)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Student__Positio__1BFD2C07");
        });

        modelBuilder.Entity<SumaryOfPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SumaryOf__3214EC27DE0B6C39");

            entity.ToTable("SumaryOfPoint");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Createby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CREATEBY");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Updateby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPDATEBY");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");

            entity.HasOne(d => d.Semester).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__SumaryOfP__Semes__403A8C7D");

            entity.HasOne(d => d.Student).WithMany(p => p.SumaryOfPoints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SumaryOfP__Stude__3F466844");
        });

        modelBuilder.Entity<TypeQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeQues__3214EC27A309F369");

            entity.ToTable("TypeQuestion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
