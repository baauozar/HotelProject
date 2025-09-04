using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.WorkLocationDto
{
    public class ResultWorkLocation
    {
        public int WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCity { get; set; }
    }
}
