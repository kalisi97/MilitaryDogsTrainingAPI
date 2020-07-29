using System;
using System.ComponentModel.DataAnnotations;

namespace MilitaryDogsTrainingAPI.Entities
{
    public class TaskEngagement
    {
        public Dog Dog { get; set; }
        public int DogId { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", NullDisplayText = "Date not yet entered!")] 
        public DateTime? Date { get; set; }
        [Range(5, 10)]
        [DisplayFormat(NullDisplayText = "Rating not entered yet!")]
        public int? Evaluation  { get; set; }
    }
}