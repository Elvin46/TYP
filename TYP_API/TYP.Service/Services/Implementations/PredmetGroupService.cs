using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core;
using TYP.Core.Entities;
using TYP.Service.DTOs.FacultyDTOs;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class PredmetGroupService : IPredmetGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PredmetGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SetCourseAsync()
        {
            List<PredmetGroup> FirstCourse = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.Group.Course ==1 && x.SessionId == 1 || x.Group.Course == 1 && x.SessionId == 2);
            foreach (var item in FirstCourse)
            {
                item.IsNow = true;
                await _unitOfWork.CommitAsync();
            }
            List<PredmetGroup> SecondCourse = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.Group.Course == 2 && x.SessionId == 3 || x.Group.Course == 2 && x.SessionId == 4);
            foreach (var item in SecondCourse)
            {
                item.IsNow = true;
                await _unitOfWork.CommitAsync();
            }
            List<PredmetGroup> ThirdCourse = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.Group.Course == 3 && x.SessionId == 5 || x.Group.Course == 3 && x.SessionId == 6);
            foreach (var item in ThirdCourse)
            {
                item.IsNow = true;
                _unitOfWork.CommitAsync();
            }
            List<PredmetGroup> FourthCourse = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.Group.Course == 4 && x.SessionId == 7 || x.Group.Course == 4 && x.SessionId == 8);
            foreach (var item in FourthCourse)
            {
                item.IsNow = true;
                _unitOfWork.CommitAsync();
            }
            
        }
        public async Task<List<PredmetGroupOutDepartmentDTO>> OutDepartment(int departmentId)
        {
            List<PredmetGroupOutDepartmentDTO> PGList = new List<PredmetGroupOutDepartmentDTO>();
            foreach (var faculty in await _unitOfWork.FacultyRepository.GetAllAsync(x=>x.IsDeleted ==false, "Professions.Groups"))
            {
                PredmetGroupOutDepartmentDTO outDepartment = new PredmetGroupOutDepartmentDTO
                {
                    FacultyDTO = _mapper.Map<FacultyGetDTO>(faculty)
                };
                foreach (var profession in faculty.Professions)
                {
                    foreach (var group in profession.Groups)
                    {
                        List<PredmetGroup> PredmetGroups = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.IsNow == true && x.GroupId == group.Id && x.TeacherId !=0, "Predmet","Session","Group.Sector","Group.Profession");
                        foreach (var predmetGroup in PredmetGroups)
                        {
                            if (predmetGroup.Session.Name.Contains("P"))
                            {
                                outDepartment.Lecturers += predmetGroup.Lecturer;
                                outDepartment.Seminars += predmetGroup.Seminar;
                                outDepartment.Laboratories += predmetGroup.Laboratory;
                                outDepartment.AdviceHours += 1;
                            }
                            else
                            {
                                outDepartment.LecturersII += predmetGroup.Lecturer;
                                outDepartment.SeminarsII += predmetGroup.Seminar;
                                outDepartment.LaboratoriesII += predmetGroup.Laboratory;
                                outDepartment.AdviceHoursII += 1;
                            }
                            

                        }
                    }
                }
                PGList.Add(outDepartment);
            }
            return PGList;
        }
        public async Task<List<PredmetGroupOutDepartmentDTO>> IntoDepartment(int departmentId)
        {
            List<PredmetGroup> PredmetGroups = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.Group.Profession.Faculty.DepartmentId == departmentId && x.Predmet.DepartmentId != departmentId, "Predmet", "Session", "Group.Sector", "Group.Profession");
            List<PredmetGroupOutDepartmentDTO> PGList = new List<PredmetGroupOutDepartmentDTO>();
            foreach (var item in PredmetGroups)
            {
                PGList.Add(_mapper.Map<PredmetGroupOutDepartmentDTO>(item));
            }
            return PGList;
        }

    }
}
