using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [AllowAnonymous]
        public ActionResult<IEnumerable<TrainingCourseDTO>> GetAll()
        {
            var entites = courseService.GetAll();
            var entitesDTO = mapper.Map<IEnumerable<TrainingCourseDTO>>(entites);
            return Ok(entitesDTO);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public ActionResult<TrainingCourseDTO> GetById(int id)
        {
            var entity = courseService.GetById(id);
            if (entity == null) return NotFound();
            var entityDTO = mapper.Map<TrainingCourseDTO>(entity);
            return Ok(entityDTO);
        }

        [HttpGet]
        [Route("[action]/{name}")]
        [AllowAnonymous]
        public ActionResult<TrainingCourseDTO> GetByName(string name)
        {
            var entity = courseService.GetBy(t=>t.Name == name);
            if (entity == null) return NotFound();
            var entityDTO = mapper.Map<TrainingCourseDTO>(entity);
            return Ok(entityDTO);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public ActionResult Put([FromBody] TrainingCourseToUpdateDTO model) 
        {
            if (ModelState.IsValid)
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
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel {
            Status = "Validation error!", Message = "You should check your input parameters!"
            });
        }
        
        [HttpGet]
        [Route("[action]/{trainingCourseId}")]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Instructor>> GetInstructorsForTrainingCourse(int trainingCourseId)
        {
            var entites = instructorService.GetAll(i => i.TrainingCourseId == trainingCourseId);
            var instructors = mapper.Map<IEnumerable<InstructorDTO>>(entites);
            return Ok(instructors);
        }
    
        [HttpDelete("id")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var entity = courseService.GetById(id);
            if (entity == null) return NotFound();
            courseService.Delete(entity);
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] TrainingCourseForCreationDTO model)
        {
            if (ModelState.IsValid)
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
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
            {
                Status = "Validation error!",
                Message = "You should check your input parameters!"
            });
        }


        [HttpPatch("courseId")]
        public ActionResult PartiallyUpdateTrainingCourse(int courseId, 
           [FromBody] JsonPatchDocument<TrainingCourseToUpdateDTO> document)
        {
            var trainingCourse = courseService.GetById(courseId);
            if (trainingCourse == null) return NotFound();
            var trainingCourseToPatch = mapper.Map<TrainingCourseToUpdateDTO>(trainingCourse);
            //add validation
            document.ApplyTo(trainingCourseToPatch);
            mapper.Map(trainingCourseToPatch, trainingCourse);
            courseService.Update(trainingCourse);
            return NoContent();

        }

    }
}