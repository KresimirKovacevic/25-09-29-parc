using EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace EF_CodeFirst.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-A081V08; Database=parc250929data; Trusted_Connection=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentName);

            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.GradeName);

            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .Property(g => g.Section)
                .HasColumnType("nchar(4)");

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student() { StudentId = 1, StudentName = "Marko Horvat", DateOfBirth = DateTime.Parse("2003-07-27"), Height = 188.9M, Weight = 90.8F },
                    new Student() { StudentId = 2, StudentName = "Maja Ivic", DateOfBirth = DateTime.Parse("2005-02-14"), Height = 176.5M, Weight = 75.2F },
                    new Student() { StudentId = 3, StudentName = "Petar Macan", DateOfBirth = DateTime.Parse("2004-04-09"), Height = 181.2M, Weight = 82.3F }
                );

            modelBuilder.Entity<Grade>()
                .HasData(
                    new Grade() { GradeId = 1, GradeName = "Introduction to Programming - 4", Section = "ABC2", StudentId = 1 },
                    new Grade() { GradeId = 2, GradeName = "Advanced Algebra - 5", Section = "ABC2", StudentId = 1 },
                    new Grade() { GradeId = 3, GradeName = "Object Oriented Programming - 4", Section = "ABC2", StudentId = 1 },
                    new Grade() { GradeId = 4, GradeName = "Introduction to Programming - 5", Section = "ABC3", StudentId = 2 },
                    new Grade() { GradeId = 5, GradeName = "Introduction to Programming - 4", Section = "ABC3", StudentId = 3 },
                    new Grade() { GradeId = 6, GradeName = "Physical Education 1 - 3", Section = "ABC2", StudentId = 1 },
                    new Grade() { GradeId = 7, GradeName = "Advanced Algebra - 3", Section = "ABC3", StudentId = 2 },
                    new Grade() { GradeId = 8, GradeName = "Advanced Algebra - 3", Section = "ABC3", StudentId = 3 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
