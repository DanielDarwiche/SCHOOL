using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCHOOL.Models
{
    public partial class SCHOOLContext : DbContext
    {
        public SCHOOLContext()
        {
        }

        public SCHOOLContext(DbContextOptions<SCHOOLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseRecord> CourseRecords { get; set; } = null!;
        public virtual DbSet<ExtraTeacher> ExtraTeachers { get; set; } = null!;
        public virtual DbSet<ExtrastudInfo> ExtrastudInfos { get; set; } = null!;
        public virtual DbSet<GradeRecord> GradeRecords { get; set; } = null!;
        public virtual DbSet<Principal> Principals { get; set; } = null!;
        public virtual DbSet<StaffOverView> StaffOverViews { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<VavgSal> VavgSals { get; set; } = null!;
        public virtual DbSet<ViewStaffOverView> ViewStaffOverViews { get; set; } = null!;
        public virtual DbSet<ViewSumSal> ViewSumSals { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-KCRC8BJ8 ; Initial Catalog = SCHOOL; \nIntegrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Administrator");

                entity.Property(e => e.AdministratorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AdministratorID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HiredSinceDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany()
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Administrator_Staff");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.HeadTeacherId).HasColumnName("HeadTeacherID");

                entity.HasOne(d => d.HeadTeacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.HeadTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Teacher");
            });

            modelBuilder.Entity<CourseRecord>(entity =>
            {
                entity.Property(e => e.CourseRecordId).HasColumnName("CourseRecordID");

                entity.Property(e => e.CourseNameId).HasColumnName("CourseNameID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseRecords)
                    .HasForeignKey(d => d.CourseNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRecords_Course1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseRecords)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRecords_Student1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.CourseRecords)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRecords_Teacher1");
            });

            modelBuilder.Entity<ExtraTeacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ExtraTeachers");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Teacher).HasMaxLength(101);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<ExtrastudInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EXTRAstudINFO");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Student).HasMaxLength(101);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Teacher).HasMaxLength(101);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<GradeRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__GradeRec__FBDF78C9CF9A1EC3");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.GradeForStudentId).HasColumnName("GradeForStudentID");

                entity.Property(e => e.GradeNameId).HasColumnName("GradeNameID");

                entity.Property(e => e.SetByTeacherId).HasColumnName("SetByTeacherID");

                entity.Property(e => e.SetDate).HasColumnType("date");

                entity.HasOne(d => d.GradeForStudent)
                    .WithMany(p => p.GradeRecords)
                    .HasForeignKey(d => d.GradeForStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeRecords_Student1");

                entity.HasOne(d => d.GradeName)
                    .WithMany(p => p.GradeRecords)
                    .HasForeignKey(d => d.GradeNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeRecords_Course");

                entity.HasOne(d => d.SetByTeacher)
                    .WithMany(p => p.GradeRecords)
                    .HasForeignKey(d => d.SetByTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeRecords_Teacher");
            });

            modelBuilder.Entity<Principal>(entity =>
            {
                entity.ToTable("Principal");

                entity.Property(e => e.PrincipalId).HasColumnName("PrincipalID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HiredSinceDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Principals)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Principal_Staff");
            });

            modelBuilder.Entity<StaffOverView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StaffOverView");

                entity.Property(e => e.AHiredDate)
                    .HasColumnType("date")
                    .HasColumnName("A. Hired Date");

                entity.Property(e => e.Admins).HasMaxLength(50);

                entity.Property(e => e.PHiredDate)
                    .HasColumnType("date")
                    .HasColumnName("P. Hired Date");

                entity.Property(e => e.Principals).HasMaxLength(50);

                entity.Property(e => e.THiredDate)
                    .HasColumnType("date")
                    .HasColumnName("T. Hired Date");

                entity.Property(e => e.Teachers).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LastNAme");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HiredSinceDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .HasDefaultValueSql("('Teacher')");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Staff");
            });

            modelBuilder.Entity<VavgSal>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VavgSal");

                entity.Property(e => e.TotalSalaryForAllAdministrators)
                    .HasColumnType("money")
                    .HasColumnName("Total salary for all Administrators");

                entity.Property(e => e.TotalSalaryForAllPrincipals)
                    .HasColumnType("money")
                    .HasColumnName("Total salary for all Principals");

                entity.Property(e => e.TotalSalaryForAllTeachers)
                    .HasColumnType("money")
                    .HasColumnName("Total salary for all teachers");
            });

            modelBuilder.Entity<ViewStaffOverView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewStaffOverView");

                entity.Property(e => e.AHiredDate)
                    .HasColumnType("date")
                    .HasColumnName("A. Hired Date");

                entity.Property(e => e.Admins).HasMaxLength(50);

                entity.Property(e => e.PHiredDate)
                    .HasColumnType("date")
                    .HasColumnName("P. Hired Date");

                entity.Property(e => e.Principals).HasMaxLength(50);

                entity.Property(e => e.THiredDate)
                    .HasColumnType("date")
                    .HasColumnName("T. Hired Date");

                entity.Property(e => e.Teachers).HasMaxLength(50);
            });

            modelBuilder.Entity<ViewSumSal>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSumSal");

                entity.Property(e => e.AverageSalaryForAdministrator)
                    .HasColumnType("money")
                    .HasColumnName("Average salary for Administrator");

                entity.Property(e => e.AverageSalaryForPrincipals)
                    .HasColumnType("money")
                    .HasColumnName("Average salary for Principals");

                entity.Property(e => e.AverageSalaryForTeachers)
                    .HasColumnType("money")
                    .HasColumnName("Average salary for teachers");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StaffRole).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
