using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;

namespace TYP.Service.DTOs.TeacherDTOs
{
    public class TeacherGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JobType { get; set; }

        public string ScientificName { get; set; }
        public string Fathername { get; set; }
        public string Department { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ScientificDegree { get; set; }
    
    }
}
