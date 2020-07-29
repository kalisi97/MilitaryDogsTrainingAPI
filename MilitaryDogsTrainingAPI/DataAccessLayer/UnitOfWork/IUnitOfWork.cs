using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.UnitOfWork
{
   public interface IUnitOfWork:IDisposable
    {
        public IDogRepository  DogRepository  { get; set; }
        public IInstructorRepository InstructorRepository { get; set; }
        public ITaskRepository TaskRepository { get; set; }
        public ITaskEngagementRepository TaskEngagementRepository { get; set; }
        public ITrainingCourseRepository TrainingCourseRepository { get; set; }

        public void Save();

    }
}
