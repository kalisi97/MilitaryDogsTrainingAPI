using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.ResourceParameters
{
    public class EntityResourceParameters
    {
        const int maxPageSize = 20;
        public string SearchQuery  { get; set; }
        public string Category { get; set; }
        public int PageNumber { get; set; } = 1;

        private int pageSize;
        public int PageSize { get => pageSize; set =>
                pageSize = (value > maxPageSize) ? maxPageSize : value;}

        public string OrderBy { get; set; } = "Name";

    }
}
