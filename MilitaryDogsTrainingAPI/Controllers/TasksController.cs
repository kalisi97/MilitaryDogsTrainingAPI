using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IDogService dogService;
        private readonly IMapper mapper;

        public TasksController(ITaskService taskService, IDogService dogService, IMapper mapper)
        {
            this.taskService = taskService;
            this.dogService = dogService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            var tasks = taskService.GetAll();
            var tasksDTO = mapper.Map<IEnumerable<TaskDTO>>(tasks);
            return Ok(tasksDTO);
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
        public ActionResult<TaskDTO> Post([FromBody] TaskForCreationDTO model)
        {
            try
            {
                var task = mapper.Map<Entities.Task>(model);           
                var dogs = model.Dogs;
               

                Entities.Task taskToInsert = new Entities.Task()
                {
                    Date = task.Date,
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
    }
}