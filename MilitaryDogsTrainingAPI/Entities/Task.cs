using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Entities
{
    public class Task
    {
        public int TaskId  { get; set; }
        [Required]
        public string Name  { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required]
        public DateTime Date  { get; set; }
        public ICollection<TaskEngagement> TaskEngagements  { get; set; }
        [Required]
        public string Location { get; set; }
        public string Status  { get; set; }
    }
}
