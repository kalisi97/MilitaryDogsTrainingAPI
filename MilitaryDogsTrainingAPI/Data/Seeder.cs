using Microsoft.AspNetCore.Identity;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext context;

        public Seeder(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (context.Database.CanConnect())
            {
                if (!context.TrainingCourses.Any())
                {
                    SeedTrainingCoursesTable(context);
                }
                if (!context.Roles.Any())
                {
                    SeedRolesTable(context);
                }

                if (!context.Users.Any())
                {
                    SeedUsersTable(context);
                }

                if (!context.UserRoles.Any())
                {
                    SeedUserRolesTable(context);
                }
                if (!context.Dogs.Any())
                {
                    SeedDogsTable(context);
                }

            }
        }

        private void SeedDogsTable(ApplicationDbContext context)
        {
            // to implement method
        }

        private void SeedUsersTable(ApplicationDbContext context)
        {

            Admin admin = new Admin()
            {
                Id = "1",
                AccessFailedCount = 0,
                ConcurrencyStamp = "b58d0834-4428-4b8b-8585-54f91a26ba71",
                Email = "admin@winesshop.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "admin@military.com",
                NormalizedUserName = "admin",
                PasswordHash = "AQAAAAEAACcQAAAAEHiB1olFqn60xI9ojOF+8WvHgi8kuCKYRt2e5LESVrtfpEn3IhVq+HYJ7BWZDXaE9w==",
                PhoneNumber = "064-201-85-28",
                PhoneNumberConfirmed = false,
                SecurityStamp = "ac1d41a1-6a1b-43d5-83d0-1eb64223e354",
                TwoFactorEnabled = false,
                UserName = "admin"

            };
            TrainingCourse trainingCourse = context.TrainingCourses.SingleOrDefault(c => c.TrainingCourseId == 1);
            Instructor i1 = new Instructor()
            {
                Id = "2",
                AccessFailedCount = 0,
                ConcurrencyStamp = "b58d0834-4428-4b8b-8585-54f91a26ba71",
                Email = "instructor1@military.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "instructor1@military.com",
                NormalizedUserName = "customer1",
                PasswordHash = "AQAAAAEAACcQAAAAEHiB1olFqn60xI9ojOF+8WvHgi8kuCKYRt2e5LESVrtfpEn3IhVq+HYJ7BWZDXaE9w==",
                PhoneNumber = "064-211-95-48",
                PhoneNumberConfirmed = false,
                SecurityStamp = "ac1d41a1-6a1b-43d5-83d0-1eb64223e354",
                TwoFactorEnabled = false,
                UserName = "instructor1",
                FullName = "Katarina Simic",
                Rank = "Desetar",
                TrainingCourseId = trainingCourse.TrainingCourseId
            };
            context.Users.AddRange(admin, i1);
            context.SaveChanges();
        }



        private void SeedUserRolesTable(ApplicationDbContext context)
        {
            context.UserRoles.AddRange(new IdentityUserRole<string>()
            {
                RoleId = "1",
                UserId = "1"
            }, new IdentityUserRole<string>() { RoleId = "2", UserId = "2" });
            context.SaveChanges();
        }

        private void SeedRolesTable(ApplicationDbContext context)
        {
            context.Roles.AddRange(new IdentityRole()
            {
                Id = "1",
                NormalizedName = "ADMIN",
                Name = "admin"

            }, new IdentityRole() { Id = "2", Name = "instructor", NormalizedName = "INSTRUCTOR" });
            context.SaveChanges();
        }

        private void SeedTrainingCoursesTable(ApplicationDbContext context)
        {
            context.TrainingCourses.AddRange(new TrainingCourse()
            {
                Duration = 5,
                Name = "Search service",
                Description = "The use of dogs to detect and track odor is the oldest use of these animals. According to the findings of modern odorology and cynology, the sense of smell of a dog is many times more subtle than in humans, and only the sense of smell depends on its limiting concentration, which is determined by the number of odor molecules per unit volume."
            }, new TrainingCourse()
            {
                Duration = 6,
                Name = "Protection service",
                Description = "This service consists of dogs that are trained for the purpose of arresting aggressive persons as well as the protection of authorized officials when performing patrol activities or other interventions. In other words, a protective dog can be used for both attack and defense purposes."
            }, new TrainingCourse()
            {
                Duration = 4,
                Name = "Guard service",
                Description = "One of the first tasks of dogs in the army was to guard military camps during the day and especially at night. Dogs would bark and howl if strangers moved near the camp and thus warned of potential danger. This training is attended by a large number of dogs and can be considered one of the most important trainings."
            }, new TrainingCourse()
            {
                Duration = 9,
                Name = "Finding narcotics",
                Description = "In this role, the tasks of military and police dogs are intertwined. As they have a very good and trained sense of smell, such dogs can easily find hidden prohibited substances at border crossings, checkpoints or airports. They also detect narcotics very easily."
            }, new TrainingCourse()
            {
                Duration = 7,
                Name = "Finding explosives",
                Description = "A large number of dogs are used to expose mines and explosives. Minesweeper dogs are trained to use bare electrical wires under the ground where electricity partially hits the dog, thus teaching him that danger lurks beneath the surface. However, finding mines for dogs is an extremely stressful activity, so they can only do it at intervals of about half an hour after which they must rest."

            });
            context.SaveChanges();
        }
    }
}

