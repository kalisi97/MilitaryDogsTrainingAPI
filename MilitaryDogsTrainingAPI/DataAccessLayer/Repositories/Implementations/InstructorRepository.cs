using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations
{
    public class InstructorRepository:GenericRepository<Instructor>,IInstructorRepository
    {
        private readonly ApplicationDbContext context;

        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
