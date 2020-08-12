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
//    [Authorize(Roles = "admin,instructor")]
    public class DogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPropertyMappingService propertyMappingService;
        private readonly IDogService dogService;
        private readonly ITrainingCourseService trainingCourseService;


        public DogController(IPropertyMappingService propertyMappingService, IMapper mapper, IDogService dogService, ITrainingCourseService trainingCourseService)
        {
            this.mapper = mapper;
            this.propertyMappingService = propertyMappingService;
            this.dogService = dogService;
            this.trainingCourseService = trainingCourseService;
        }

        [HttpGet(Name = "GetDogs")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<DogDTO>> GetDogs([FromQuery] EntityResourceParameters parameters)
        {
            //ako ne postoji mapa za unet properti za odgovarajuce klase, vracamo gresku sa 
            // statusnim kodom 400

            if (!propertyMappingService.ValidMappingExistsFor<DogDTO, Dog>(parameters.OrderBy))
                return BadRequest();
            if (parameters.PageSize == 0) parameters.PageSize = dogService.GetAll().ToList().Count();
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

        [HttpGet("id")]
        [AllowAnonymous]
        public ActionResult<DogDTO> Get(int id)
        {
            var dog = dogService.GetById(id);
            if (dog == null) return NotFound();
            var dogDTO = mapper.Map<DogDTO>(dog);
            return Ok(dogDTO);
        }

        [HttpPost]
        public ActionResult<DogDTO> Post([FromBody] DogForCreationDTO model)
        {
            var dog = mapper.Map<Dog>(model);
            TrainingCourse trainingCourse = trainingCourseService.GetBy(t=>t.Name == model.TrainingCourse);
            Dog dogToInsert = new Dog()
            {
                Breed = dog.Breed,
                ChipNumber = dog.ChipNumber,
                DateOfBirth = dog.DateOfBirth,
                Gender = dog.Gender,
                Name = dog.Gender,
                TrainingCourse = trainingCourse
            };
            dogService.Insert(dog);
            DogDTO dogDTO = mapper.Map<DogDTO>(dog);
            return Ok(dogDTO);
          //  return Created($"api/dogs/get/{dogDTO.Name}", dogDTO);
        }

        [HttpPut]
        public ActionResult<DogDTO> Put([FromBody] DogForUpdateDTO model)
        {
            try
            {
                var dog = mapper.Map<Dog>(model);
                TrainingCourse trainingCourse = trainingCourseService.GetBy(t => t.Name == model.TrainingCourse);
                Dog dogFromDatabase = dogService.GetById(model.Id);
                if (dogFromDatabase == null) return NotFound();
                dogFromDatabase.Breed = dog.Breed;
                dogFromDatabase.Name = dog.Name;
                dogFromDatabase.TaskEngagements = dog.TaskEngagements;
                dogFromDatabase.TrainingCourseId = dog.TrainingCourseId;
                dogFromDatabase.DateOfBirth = dogFromDatabase.DateOfBirth;
                dogFromDatabase.ChipNumber = dog.ChipNumber;
                dogFromDatabase.TrainingCourseId = trainingCourse.TrainingCourseId;
                dogService.Update(dogFromDatabase);
                DogDTO dogDTO = mapper.Map<DogDTO>(dogFromDatabase);
                //    return Created($"api/dogs/get/{dogDTO.Name}", dogDTO);
                return Ok(dogDTO);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete("dogId")]
        public ActionResult Delete(int dogId)
        {
            Dog dogFromDatabase = dogService.GetById(dogId);
            if (dogFromDatabase == null) return NotFound();
            dogService.Delete(dogFromDatabase);
            return NoContent();
        }

        private string CreateDogsResourceUri(EntityResourceParameters parameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetDogs",
                      new
                      {
                          orderBy = parameters.OrderBy,
                          pageNumber = parameters.PageNumber - 1,
                          pageSize = parameters.PageSize,
                          mainCategory = parameters.Category,
                          searchQuery = parameters.SearchQuery
                      });
                case ResourceUriType.NextPage:
                    return Url.Link("GetDogs",
                      new
                      {
                          orderBy = parameters.OrderBy,
                          pageNumber = parameters.PageNumber + 1,
                          pageSize = parameters.PageSize,
                          mainCategory = parameters.Category,
                          searchQuery = parameters.SearchQuery
                      });

                default:
                    return Url.Link("GetDogs",
                    new
                    {
                        orderBy = parameters.OrderBy,
                        pageNumber = parameters.PageNumber,
                        pageSize = parameters.PageSize,
                        mainCategory = parameters.Category,
                        searchQuery = parameters.SearchQuery
                    });
            }
        }
    }
}
