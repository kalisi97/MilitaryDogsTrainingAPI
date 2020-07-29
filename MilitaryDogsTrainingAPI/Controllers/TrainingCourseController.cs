using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Models;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCourseController : ControllerBase
    {
        private readonly ITrainingCourseService courseService;
        private readonly IMapper mapper;

        public TrainingCourseController(ITrainingCourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        [HttpGet]

        public ActionResult<IEnumerable<TrainingCourseDTO>> GetAll()
        {
            var entites = courseService.GetAll();
            var entitesDTO = mapper.Map<IEnumerable<TrainingCourseDTO>>(entites);
            return Ok(entitesDTO);
        }
    }
}