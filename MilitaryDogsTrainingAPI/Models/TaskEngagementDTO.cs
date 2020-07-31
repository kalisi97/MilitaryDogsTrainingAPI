using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class TaskEngagementDTO
    {
        public string Dog  { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", NullDisplayText = "Date not yet entered!")]
        public DateTime? Date { get; set; }
        [Range(5, 10)]
        [DisplayFormat(NullDisplayText = "Rating not entered yet!")]
        public int? Evaluation { get; set; }
    }
}
