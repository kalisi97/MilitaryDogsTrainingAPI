using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.ValidationAttributes
{

    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var course = (TrainingCourseDTO)validationContext.ObjectInstance;

            if (course.Name == course.Description)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(TrainingCourseDTO) });
            }

            return ValidationResult.Success;
        }
    }
}
