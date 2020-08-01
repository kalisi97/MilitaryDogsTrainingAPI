using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.ValidationAttributes
{
    public class TheDateOfBirthValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dog = (DogForCreationDTO)validationContext.ObjectInstance;

            if (dog.DateOfBirth > DateTime.Now)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(DogForCreationDTO) });
            }

            return ValidationResult.Success;
        }
    }
}
