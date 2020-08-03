using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations
{
    public class TrainingCourseRepository:GenericRepository<TrainingCourse>, ITrainingCourseRepository
    {
        private readonly ApplicationDbContext context;

        public TrainingCourseRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
        public override IEnumerable<TrainingCourse> GetAll()
        {
            return context.TrainingCourses.AsNoTracking().Include(t => t.Dogs).Include(t => t.Instructors);
        }
    }
}
