using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.DTOs.FacultyDTOs;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.JobTypeDTOs;
using TYP.Service.DTOs.PredmetDTOs;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.DTOs.PredmetProfessionDTOs;
using TYP.Service.DTOs.ProfessionDTOs;
using TYP.Service.DTOs.ScientificDegreeDTOs;
using TYP.Service.DTOs.ScientificNameDTOs;
using TYP.Service.DTOs.SectorDTOs;
using TYP.Service.DTOs.TeacherDTOs;

namespace TYP.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherGetDTO>()
                .ForMember(x => x.Department, y => y.MapFrom(x => x.Department.Name))
                .ForMember(x => x.JobType, y => y.MapFrom(x => x.JobType.Name))
                .ForMember(x => x.ScientificDegree, y => y.MapFrom(x => x.ScientificDegree.Name))
                .ForMember(x => x.ScientificName, y => y.MapFrom(x => x.ScientificName.Name))
                .ForMember(x => x.Sex, y => y.MapFrom(x => x.Sex.Name));
            CreateMap<Teacher, TeacherGetAllDTO>();
            CreateMap<TeacherPostDTO, Teacher>().ReverseMap();

            CreateMap<ScientificDegree, ScientificDegreeGetDTO>()
                .ForMember(x => x.Teachers, y => y.MapFrom(x => x.Teachers));
            CreateMap<ScientificDegree, ScientificDegreeGetAllDTO>();
            CreateMap<ScientificDegreePostDTO, ScientificDegree>().ReverseMap();

            CreateMap<ScientificName, ScientificNameGetDTO>()
                .ForMember(x => x.Teachers, y => y.MapFrom(x => x.Teachers));
            CreateMap<ScientificName, ScientificNameGetAllDTO>();
            CreateMap<ScientificNamePostDTO, ScientificName>().ReverseMap();

            CreateMap<Department, DepartmentGetDTO>()
                .ForMember(x => x.Teachers, y => y.MapFrom(x => x.Teachers));
            CreateMap<Department, DepartmentGetAllDTO>();
            CreateMap<DepartmentPostDTO, Department>().ReverseMap();

            CreateMap<Faculty, FacultyGetDTO>();
            CreateMap<Faculty, FacultyGetAllDTO>();
            CreateMap<FacultyPostDTO, Faculty>().ReverseMap();

            CreateMap<JobType, JobTypeGetDTO>()
                .ForMember(x => x.Teachers, y => y.MapFrom(x => x.Teachers));
            CreateMap<JobType, JobTypeGetAllDTO>();
            CreateMap<JobTypePostDTO, JobType>().ReverseMap();

            CreateMap<Predmet, PredmetGetDTO>();
            CreateMap<Predmet, PredmetGetAllDTO>();
            CreateMap<PredmetPostDTO, Predmet>().ReverseMap();

            CreateMap<PredmetProfession, PredmetProfessionGetDTO>()
                .ForMember(x=>x.PredmetName,y=>y.MapFrom(x=>x.Predmet.Name))
                .ForMember(x=>x.Session,y=>y.MapFrom(x=>x.Session.Name));
            CreateMap<PredmetProfession, PredmetProfessionMapDTO>();
            CreateMap<PredmetProfession, PredmetProfessionGetAllDTO>();
            CreateMap<PredmetProfessionPostDTO, PredmetProfession>().ReverseMap();

            CreateMap<PredmetGroup, PredmetGroupGetDTO>()
                .ForMember(x => x.PredmetName, y => y.MapFrom(x => x.Predmet.Name))
                .ForMember(x => x.Group, y => y.MapFrom(x => x.Group.Number))
                .ForMember(x => x.Course, y => y.MapFrom(x => x.Group.Course))
                .ForMember(x => x.Sector, y => y.MapFrom(x => x.Group.Sector.Code))
                .ForMember(x => x.Session, y => y.MapFrom(x => x.Session.Name))
                .ForMember(x=>x.Faculty,y=> y.MapFrom(x=>x.Group.Profession.Faculty.Name))
                .ForMember(x => x.Profession, y => y.MapFrom(x => x.Group.Profession.Name));

            CreateMap<Profession, ProfessionGetDTO>()
                .ForMember(x => x.FacultyName, y => y.MapFrom(x => x.Faculty.Name));
            CreateMap<Profession, ProfessionGetAllDTO>();
            CreateMap<ProfessionPostDTO, Profession>().ReverseMap();


            CreateMap<Group, GroupGetDTO>()
                .ForMember(x => x.SectorCode, y => y.MapFrom(x => x.Sector.Code));
            CreateMap<Group, GroupGetAllDTO>();
            CreateMap<GroupPostDTO, Group>().ReverseMap();

            CreateMap<Sector, SectorGetDTO>();
            CreateMap<Sector, SectorGetAllDTO>();
            CreateMap<SectorPostDTO, Sector>().ReverseMap();
            CreateMap<SectorEditDTO, Sector>().ReverseMap();

            CreateMap<PredmetProfession, PredmetGroup>();
            CreateMap<PredmetProfessionPostDTO, PredmetGroup>();
            CreateMap<PredmetProfessionMapDTO, PredmetGroup>();
        }
    }
}
