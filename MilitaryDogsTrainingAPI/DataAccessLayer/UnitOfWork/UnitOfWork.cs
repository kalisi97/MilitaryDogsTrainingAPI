using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDogRepository DogRepository  {get; set;} 
        public IInstructorRepository InstructorRepository  {get; set;} 
        public ITaskRepository TaskRepository  {get; set;} 
        public ITaskEngagementRepository TaskEngagementRepository {get; set;} 
        public ITrainingCourseRepository TrainingCourseRepository  {get; set;} 
        public IPropertyMappingService propertyMappingService { get; set; }

        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context, IPropertyMappingService propertyMappingService)
        {
            this.context = context;
            this.propertyMappingService = propertyMappingService;
            DogRepository = new DogRepository(context,propertyMappingService);
            InstructorRepository = new InstructorRepository(context);
            TaskRepository = new  TaskRepository(context);
            TaskEngagementRepository =  new TaskEngagementRepository(context);
            TrainingCourseRepository = new TrainingCourseRepository(context);   
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
