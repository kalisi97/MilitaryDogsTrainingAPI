using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Admin> Admins  { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Dog> Dogs  { get; set; }
        public DbSet<Entities.Task> Tasks  { get; set; }
        public DbSet<TaskEngagement> TaskEngagements { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrainingCourse>().ToTable("TrainingCourses");
            builder.Entity<TrainingCourse>().HasKey(t=>t.TrainingCourseId);

            builder.Entity<Dog>().ToTable("Dogs");
            builder.Entity<Dog>().HasKey(d => d.DogId);
            builder.Entity<Dog>().HasOne(d => d.TrainingCourse).WithMany(t => t.Dogs).HasForeignKey(d => d.TrainingCourseId);

            builder.Entity<Instructor>().HasOne(i => i.TrainingCourse).WithMany(t => t.Instructors).HasForeignKey(i => i.TrainingCourseId);

            builder.Entity<TaskEngagement>().ToTable("TaskEngagements");
            builder.Entity<TaskEngagement>().HasKey(e => new { e.DogId, e.TaskId });
            builder.Entity<TaskEngagement>().HasOne(e => e.Dog).WithMany(d => d.TaskEngagements).HasForeignKey(e => e.DogId);
            builder.Entity<TaskEngagement>().HasOne(e => e.Task).WithMany(t => t.TaskEngagements).HasForeignKey(e => e.TaskId);

            builder.Entity<Entities.Task>().ToTable("Tasks");
            builder.Entity<Entities.Task>().HasKey(t => t.TaskId);
        }
    }
}
