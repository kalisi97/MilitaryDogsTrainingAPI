using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCourseController : ControllerBase
    {
        private readonly ITrainingCourseService courseService;
        private readonly IInstructorService instructorService;
        private readonly IMapper mapper;

        public TrainingCourseController(IInstructorService instructorService,ITrainingCourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.instructorService = instructorService;
            this.mapper = mapper;
        }

        [HttpGet]

        public ActionResult<IEnumerable<TrainingCourseDTO>> GetAll()
        {
            var entites = courseService.GetAll();
            var entitesDTO = mapper.Map<IEnumerable<TrainingCourseDTO>>(entites);
            return Ok(entitesDTO);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<TrainingCourseDTO> GetById(int id)
        {
            var entity = courseService.GetById(id);
            if (entity == null) return NotFound();
            var entityDTO = mapper.Map<TrainingCourseDTO>(entity);
            return Ok(entityDTO);
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public ActionResult<TrainingCourseDTO> GetByName(string name)
        {
            var entity = courseService.GetBy(t=>t.Name == name);
            if (entity == null) return NotFound();
            var entityDTO = mapper.Map<TrainingCourseDTO>(entity);
            return Ok(entityDTO);
        }

        [HttpPut]
        public ActionResult Put([FromBody] TrainingCourseToUpdateDTO model) 
        { 
            var trainingCourseFromDataBase = courseService.GetBy(t => t.Name == model.Name);
            if (trainingCourseFromDataBase == null) return NotFound();
            trainingCourseFromDataBase.Name = model.Name;
            trainingCourseFromDataBase.Description = model.Description;
            trainingCourseFromDataBase.Duration = model.Duration;
          
            courseService.Update(trainingCourseFromDataBase);
            var trainingCourseDTO = mapper.Map<TrainingCourseDTO>(trainingCourseFromDataBase);
            return Ok(trainingCourseDTO);    
        }
        
        [HttpGet]
        [Route("[action]/{trainingCourseId}")]
        public ActionResult<IEnumerable<Instructor>> GetInstructorsForTrainingCourse(int trainingCourseId)
        {
            var entites = instructorService.GetAll(i => i.TrainingCourseId == trainingCourseId);
            var instructors = mapper.Map<IEnumerable<InstructorDTO>>(entites);
            return Ok(instructors);
        }
    
        [HttpDelete("id")]

        public IActionResult Delete(int id)
        {
            var entity = courseService.GetById(id);
            if (entity == null) return NotFound();
            courseService.Delete(entity);
            return NoContent();
        }

        [HttpPost]

        public IActionResult Post([FromBody] TrainingCourseForCreationDTO model)
        {
            var entity = mapper.Map<TrainingCourse>(model);
            TrainingCourse trainingCourse = new TrainingCourse()
            {
                Description = entity.Description,
                Duration = entity.Duration,
                Name = entity.Name
            };
            courseService.Insert(trainingCourse);
            return Ok();
        }
    }
}