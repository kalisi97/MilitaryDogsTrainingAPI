using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Models;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,instructor")]
    public class TaskEngagementsController : ControllerBase
    {
        private readonly ITaskEngagementService taskEngagementService;
        private IMapper mapper;

        public TaskEngagementsController(ITaskEngagementService taskEngagementService, IMapper mapper)
        {
            this.taskEngagementService = taskEngagementService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<TaskEngagementDetailsDTO> Get()
        {
            var taskEngagements = taskEngagementService.GetAll();
            var taskEngagementsDTO = mapper.Map<IEnumerable<TaskEngagementDetailsDTO>>(taskEngagements);
            return Ok(taskEngagementsDTO);
        }

        [HttpGet("dogId,taskId")]

        public ActionResult<TaskEngagementDetailsDTO> Get(int dogId, int taskId)
        {
            var taskEngagement = taskEngagementService.GetById(dogId, taskId);
            if (taskEngagement == null) return NotFound();
            var taskEngagementDTO = mapper.Map<TaskEngagementDetailsDTO>(taskEngagement);
            return Ok(taskEngagementDTO);
        }

        [HttpPut("dogId,taskId")]

        public ActionResult<TaskEngagementDetailsDTO> Put(int dogId, int taskId, [FromBody] int evaluation)
        {
            //evaluation range 5-10
            if (ModelState.IsValid && evaluation > 5 && evaluation < 11)
            {
                var taskEngagementFromDatabase = taskEngagementService.GetById(dogId, taskId);
                if (taskEngagementFromDatabase == null) return NotFound();
                taskEngagementFromDatabase.Evaluation = evaluation;
                taskEngagementFromDatabase.Date = DateTime.Now;
                taskEngagementService.Update(taskEngagementFromDatabase);
                var taskEngagementDTO = mapper.Map<TaskEngagementDetailsDTO>(taskEngagementFromDatabase);
                return Ok(taskEngagementDTO);
            }
            return StatusCode(StatusCodes.Status422UnprocessableEntity, new ResponseModel
            {
                Status = "Validation error!",
                Message = "You should check your input parameters!"
            });
        }
        [HttpDelete("dogId,taskId")]
        public ActionResult Delete(int dogId, int taskId)
        {

            var taskEngagementFromDatabase = taskEngagementService.GetById(dogId, taskId);
            if (taskEngagementFromDatabase == null) return NotFound();
            taskEngagementService.Delete(taskEngagementFromDatabase);
            return NoContent();
        }
    }
}