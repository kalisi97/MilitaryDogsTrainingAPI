using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IDogService dogService;
        private readonly ITaskEngagementService taskEngagementService;
        private readonly IMapper mapper;

        public TasksController(ITaskEngagementService taskEngagementService, ITaskService taskService, IDogService dogService, IMapper mapper)
        {
            this.taskService = taskService;
            this.dogService = dogService;
            this.taskEngagementService = taskEngagementService;
            this.mapper = mapper;
        }

        [HttpGet]
     //   [Authorize(Roles = "admin,instructor")]
     [AllowAnonymous]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            var tasks = taskService.GetAll();
            var tasksDTO = mapper.Map<IEnumerable<TaskDTO>>(tasks);
            return Ok(tasksDTO);
        }

        [HttpPut("id")]

        public ActionResult Put(int taskId,[FromBody] TaskForManipulationDTO taskDTO)
        {
            var entity = mapper.Map<Entities.Task>(taskDTO);
            var taskFromDatabase = taskService.GetById(taskId);
            if (taskFromDatabase == null) return NotFound();
            taskFromDatabase.Location = entity.Location;
            taskFromDatabase.Name = entity.Name;
            taskService.Update(taskFromDatabase);
            var taskUpdatedDTO = mapper.Map<TaskDTO>(taskFromDatabase);
            return Ok(taskUpdatedDTO);
        }

        [HttpGet("id")]
       
        public ActionResult<TaskDTO> Get(int id)
        {
            var task = taskService.GetById(id);
            if (task == null) return NotFound();
            var taskDTO = mapper.Map<TaskDTO>(task);
            return Ok(taskDTO);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<TaskDTO> Post([FromBody] TaskForCreationDTO model)
        {
            try
            {
                var task = mapper.Map<Entities.Task>(model);           
                var dogs = model.Dogs;
               

                Entities.Task taskToInsert = new Entities.Task()
                {
                    Date = model.Date,
                    Location = task.Location,
                    Name = task.Name,
                    Status = "Created",

                };

                List<TaskEngagement> taskEngagementsToInsert = new List<TaskEngagement>();

                foreach (DogDTO d in dogs)
                {
                    Dog entity = dogService.GetBy(e => e.ChipNumber == d.ChipNumber);
                    TaskEngagement taskEngagement = new TaskEngagement()
                    {
                        Date = null,
                        Evaluation = null,
                        Dog = entity, 
                        Task = taskToInsert,
                        TaskId = taskToInsert.TaskId
                    };

                    taskEngagementsToInsert.Add(taskEngagement);
                }

                taskToInsert.TaskEngagements = taskEngagementsToInsert;
                taskService.Insert(taskToInsert);
                TaskDTO taskDTO = mapper.Map<TaskDTO>(taskToInsert);
                return Created($"api/tasks/{taskToInsert.TaskId}", taskDTO);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var task = taskService.GetById(id);
            if (task == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            taskService.Delete(task);
            return NoContent();
        }

        [HttpGet]
        [Route("[action]/{taskId}")]
        [Authorize(Roles = "admin,instructor")]
        public ActionResult<IEnumerable<TaskEngagementDTO>> GetTaskEngagementsForTask(int taskId)
        {
            var taskEngagements = taskEngagementService.GetAll(t => t.TaskId == taskId);
            var taskEngagementsDTOs = mapper.Map<IEnumerable<TaskEngagementDTO>>(taskEngagements);
            return Ok(taskEngagementsDTOs);
        }
    }
}