using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Helpers;
using MilitaryDogsTrainingAPI.Models;
using MilitaryDogsTrainingAPI.ResourceParameters;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,instructor")]
    public class DogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDogService dogService;
        private readonly ITrainingCourseService trainingCourseService;


        public DogController(IMapper mapper, IDogService dogService, ITrainingCourseService trainingCourseService)
        {
            this.mapper = mapper;
            this.dogService = dogService;
            this.trainingCourseService = trainingCourseService;
        }

        [HttpGet(Name = "GetDogs")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DogDTO>> GetDogs([FromQuery] EntityResourceParameters parameters)
        {

            var dogs = dogService.GetAll(parameters);
            var previousPageLink = dogs.HasPrevious ?
             CreateDogsResourceUri(parameters,
             ResourceUriType.PreviousPage) : null;

            var nextPageLink = dogs.HasNext ?
                CreateDogsResourceUri(parameters,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = dogs.TotalCount,
                pageSize = dogs.PageSize,
                currentPage = dogs.CurrentPage,
                totalPages = dogs.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            var dogsDTO = mapper.Map<IEnumerable<DogDTO>>(dogs);
            return Ok(dogsDTO);
        }

        [HttpGet("name")]

        public ActionResult<IEnumerable<DogDTO>> Get(string name)
        {
            var dogs = dogService.GetAll(d => d.Name == name);
            if (dogs == null) return NotFound();
            var dogDTO = mapper.Map<IEnumerable<DogDTO>>(dogs);
            return Ok(dogDTO);
        }
        [HttpPost]
        public ActionResult<DogDTO> Post([FromBody] DogForCreationDTO model)
        {
            var dog = mapper.Map<Dog>(model);
            TrainingCourse trainingCourse = trainingCourseService.GetById(dog.TrainingCourseId);
            Dog dogToInsert = new Dog()
            {
                Breed = dog.Breed,
                ChipNumber = dog.ChipNumber,
                DateOfBirth = dog.DateOfBirth,
                Gender = dog.Gender,
                Name = dog.Gender,
                TrainingCourseId = trainingCourse.TrainingCourseId
            };
            dogService.Insert(dog);
            DogDTO dogDTO = mapper.Map<DogDTO>(dog);
            return Created($"api/dogs/get/{dogDTO.Name}", dogDTO);
        }

        [HttpPut("dogId")]
        public ActionResult<DogDTO> Put(int dogId, [FromBody] DogForUpdateDTO model)
        {
            var dog = mapper.Map<Dog>(model);
            TrainingCourse trainingCourse = trainingCourseService.GetById(model.TrainingCourseId);
            Dog dogFromDatabase = dogService.GetById(dogId);
            if (dogFromDatabase == null) return NotFound();
            dogFromDatabase.Breed = dog.Breed;
            dogFromDatabase.Name = dog.Name;
            dogFromDatabase.TaskEngagements = dog.TaskEngagements;
            dogFromDatabase.TrainingCourseId = dog.TrainingCourseId;
            dogFromDatabase.DateOfBirth = dog.DateOfBirth;
            dogFromDatabase.ChipNumber = dog.ChipNumber;
            dogService.Update(dogFromDatabase);
            DogDTO dogDTO = mapper.Map<DogDTO>(dogFromDatabase);
            return Created($"api/dogs/get/{dogDTO.Name}", dogDTO);

        }

        [HttpDelete("dogId")]

        public IActionResult Delete(int dogId)
        {
            Dog dogFromDatabase = dogService.GetById(dogId);
            if (dogFromDatabase == null) return NotFound();
            dogService.Delete(dogFromDatabase);
            return NoContent();
        }

        private string CreateDogsResourceUri(
         EntityResourceParameters authorsResourceParameters,
         ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetDogs",
                      new
                      {
                          pageNumber = authorsResourceParameters.PageNumber - 1,
                          pageSize = authorsResourceParameters.PageSize,
                          mainCategory = authorsResourceParameters.Category,
                          searchQuery = authorsResourceParameters.SearchQuery
                      });
                case ResourceUriType.NextPage:
                    return Url.Link("GetDogs",
                      new
                      {
                          pageNumber = authorsResourceParameters.PageNumber + 1,
                          pageSize = authorsResourceParameters.PageSize,
                          mainCategory = authorsResourceParameters.Category,
                          searchQuery = authorsResourceParameters.SearchQuery
                      });

                default:
                    return Url.Link("GetDogs",
                    new
                    {
                        pageNumber = authorsResourceParameters.PageNumber,
                        pageSize = authorsResourceParameters.PageSize,
                        mainCategory = authorsResourceParameters.Category,
                        searchQuery = authorsResourceParameters.SearchQuery
                    });
            }
        }
    }
}
