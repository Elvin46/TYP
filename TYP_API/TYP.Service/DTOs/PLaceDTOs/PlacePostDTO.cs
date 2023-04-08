using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PLaceDTOs
{
    public class PlacePostDTO
    {
        public string Name { get; set; }
    }
    public class TeacherPlacePostDTO
    {
        public string PlaceName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
