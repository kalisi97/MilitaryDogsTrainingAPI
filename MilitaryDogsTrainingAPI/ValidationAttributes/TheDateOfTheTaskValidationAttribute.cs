using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.ValidationAttributes
{
    public class TheDateOfTheTaskValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var task = (TaskForCreationDTO)validationContext.ObjectInstance;

            if (task.Date <= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(TaskForCreationDTO) });
            }

            return ValidationResult.Success;
        }
    }
}
