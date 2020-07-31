﻿using System;
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

        [HttpGet]
        public ActionResult<IEnumerable<DogDTO>> GetAll()
        {
            var dogs = dogService.GetAll();
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
    }
}