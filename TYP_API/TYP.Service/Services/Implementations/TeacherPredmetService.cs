using AutoMapper;
using RMS.Service.DTOs;
using RMS.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core;
using TYP.Core.Entities;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.DTOs.TeacherPredmetDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class TeacherPredmetService : ITeacherPredmetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherPredmetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(TeacherPredmetPostDTO TeacherPredmetDTO)
        {
            PredmetGroup predmetGroup = await _unitOfWork.PredmetGroupRepository.GetAsync(x => x.Id == TeacherPredmetDTO.PredmetGroupId);
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == TeacherPredmetDTO.TeacherId,"PredmetGroups");
            if (predmetGroup.TeacherId !=null)
                throw new Exception($"This predmet is already taken. Please change name!");
            int teachersHours = 0;
            foreach (var item in teacher.PredmetGroups)
            {
                teachersHours += item.AuditoryHours;
            }
            if (teacher.JobTypeId == 1)
            {
                if (teachersHours < 625 && teachersHours > 540)
                {
                    throw new Exception("Bu Muellimin Yuku artiq tamdir!!");
                }
            }
            if (teacher.JobTypeId == 3)
            {
                if (teachersHours < 340 && teachersHours > 270)
                {
                    throw new Exception("Bu Muellimin Yuku artiq tamdir!!");
                }
            }
            predmetGroup.TeacherId = TeacherPredmetDTO.TeacherId;
            teacher.PredmetGroups.Add(predmetGroup);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            TeacherPredmet TeacherPredmet = await _unitOfWork.TeacherPredmetRepository.GetAsync(x => x.Id == id);
            if (TeacherPredmet == null)
            {
                throw new NotFoundException("TeacherPredmet doesn't exist in this Id");
            }
            TeacherPredmet.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, TeacherPredmetPostDTO TeacherPredmetDTO)
        {
            TeacherPredmet TeacherPredmet = await _unitOfWork.TeacherPredmetRepository.GetAsync(x => x.Id == id);
            if (TeacherPredmet == null)
            {
                throw new NotFoundException("TeacherPredmet doesn't exist in this Id");
            }
            //if (await _unitOfWork.TeacherPredmetRepository.IsExistAsync(x => x.Id != id && x.GroupId == TeacherPredmetDTO.GroupId))
            //{
            //    throw new AlreadyExistException($"This Predmet is already exist. Please change name!");
            //}
            _mapper.Map<TeacherPredmetPostDTO, TeacherPredmet>(TeacherPredmetDTO, TeacherPredmet);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<PredmetGroupGetDTO>> GetAllAsync(int teacherId)
        {
            List<PredmetGroup> pgs = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.IsDeleted == false && x.TeacherId == teacherId, "Session", "Predmet", "Group.Sector", "Group.Profession.Faculty");
            List<PredmetGroupGetDTO> pgList = new List<PredmetGroupGetDTO>();
            foreach (var item in pgs)
            {
                pgList.Add(_mapper.Map<PredmetGroupGetDTO>(item));
            }
            return pgList;
        }
        //public async Task<GroupGetAllDTO> GetAllPredmetAsync(int id)
        //{
        //    Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == id, "Department.FacultyDepartments.Faculty.Professions.Groups", "TeacherSectors.Sector");
        //    List<FacultyDepartment> facultyDepartments = teacher.Department.FacultyDepartments.ToList();
        //    List<PredmetProfession> entities = new List<PredmetProfession>();
        //    List<Group> groups = new List<Group>();
        //    foreach (var item in facultyDepartments)
        //    {
        //        foreach (var profession in item.Faculty.Professions)
        //        {
        //            foreach (var predmetProfession in await _unitOfWork.PredmetProfessionRepository.GetAllAsync(x => x.IsDeleted == false && x.ProfessionId == profession.Id))
        //            {
        //                entities.Add(predmetProfession);
        //            }
        //            foreach (var group in profession.Groups)
        //            {
        //                foreach (var sector in teacher.TeacherSectors)
        //                {
        //                    if (group.SectorId == sector.SectorId)
        //                    {
        //                        groups.Add(group);
        //                    }
        //                }
        //            }

        //        }

        //    }
        //    List<GroupGetDTO> groupsDTO = new List<GroupGetDTO>();
        //    foreach (var item in groups)
        //    {
        //        groupsDTO.Add(_mapper.Map<GroupGetDTO>(item));
        //    }
        //    int count = await _unitOfWork.TeacherPredmetRepository.GetTotalCountAsync(x => x.IsDeleted == false);
        //    GroupGetAllDTO GroupGetAll = new GroupGetAllDTO
        //    {
        //        Groups = groupsDTO,
        //        Count = count
        //    };
        //    return GroupGetAll;
        //}
        public async Task<TeacherPredmetPostViewDTO> GetAllPredmetAsync(int id)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == id, "Department", "TeacherSectors.Sector", "TeacherCertifications.Certification","PredmetGroups");
            List<PredmetGroupGetDTO> PGs = new List<PredmetGroupGetDTO>();
            List<int> orderBys = new List<int>();
            List<PredmetGroupGetDTO> mainPGs = new List<PredmetGroupGetDTO>();

            List<TeacherPredmet> teacherPredmets = await _unitOfWork.TeacherPredmetRepository.GetAllAsync(x => x.TeacherId == id && x.IsDeleted == false);
            
            foreach (var teacherSector in teacher.TeacherSectors.OrderByDescending(x => x.Level))
            {
                foreach (var TP in teacherPredmets)
                {
                    List<PredmetGroup> PG = await _unitOfWork.PredmetGroupRepository.GetAllAsync(x => x.PredmetId == TP.PredmetId && x.Group.SectorId == teacherSector.SectorId && x.IsNow == true , "Session", "Predmet", "Group.Sector", "Group.Profession");
                    foreach (var item in PG)
                    {
                        PGs.Add(_mapper.Map<PredmetGroupGetDTO>(item));
                        if (item.orderBy != 0)
                        {
                            if (!orderBys.Contains(item.orderBy))
                            {
                                orderBys.Add(item.orderBy);
                            }
                        }
                    }
                }



            }
            for (int i = 0; i < teacher.TeacherCertifications.Count(); i++)
            {
                if (i == 0)
                {
                    mainPGs = PGs.OrderByDescending(x => x.PredmetName == teacher.TeacherCertifications.ToList()[i].Certification.Name).ToList();
                }
                else
                {
                    mainPGs = mainPGs.OrderByDescending(x => x.PredmetName == teacher.TeacherCertifications.ToList()[i].Certification.Name).ToList();
                }
            }
            int teachersHours = 0;
            foreach (var item in teacher.PredmetGroups)
            {
                teachersHours += item.AuditoryHours;
            }
            TeacherPredmetPostViewDTO returnDTO = new TeacherPredmetPostViewDTO
            {
                PredmetGroups = PGs,
                OrderBys = orderBys,
                TeachersHours = teachersHours
            };
            //if (mainPGs.Count() == 0)
            //{
            //    returnDTO = new TeacherPredmetPostViewDTO
            //    {
            //        PredmetGroups = PGs,
            //        OrderBys = orderBys,
            //        TeachersHours = teachersHours
            //    };
            //}
            //else
            //{
            //    returnDTO = new TeacherPredmetPostViewDTO
            //    {
            //        PredmetGroups = mainPGs,
            //        OrderBys = orderBys,
            //        TeachersHours = teachersHours
            //    };
            //}

            return returnDTO;
        }
        public async Task<PagenatedListDTO<TeacherPredmetGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<TeacherPredmet> TeacherPredmets = await _unitOfWork.TeacherPredmetRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Teachers");
            if (search.Length == 0)
            {
                TeacherPredmets = await _unitOfWork.TeacherPredmetRepository.GetAllPagenatedAsync(x => x.IsDeleted == false /*&& x.Group..Contains(search)*/, page, pageSize);
            }
            List<TeacherPredmetGetDTO> TeacherPredmetsListDto = new List<TeacherPredmetGetDTO>();
            foreach (var item in TeacherPredmets)
            {
                _mapper.Map<TeacherPredmetGetDTO>(item);
                TeacherPredmetsListDto.Add(_mapper.Map<TeacherPredmetGetDTO>(item));
            }
            int count = await _unitOfWork.TeacherPredmetRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<TeacherPredmetGetDTO> pagenatedTeacherPredmets = new PagenatedListDTO<TeacherPredmetGetDTO>(TeacherPredmetsListDto, page, count, pageSize);
            return pagenatedTeacherPredmets;
        }
        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            TeacherPredmet TeacherPredmet = await _unitOfWork.TeacherPredmetRepository.GetAsync(x => x.Id == id, "Teachers");
            if (TeacherPredmet == null) throw new Exception("TeacherPredmet doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(TeacherPredmet);
            return entity;
        }
        public async Task<TEntity> GetAsync<TEntity>(int TeacherId,int PredmetGroupId)
        {
            TeacherPredmet TeacherPredmet = await _unitOfWork.TeacherPredmetRepository.GetAsync(x => x.IsDeleted == false && x.TeacherId == TeacherId && x.PredmetGroupId == PredmetGroupId);
            if (TeacherPredmet == null) throw new Exception("TeacherPredmet doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(TeacherPredmet);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.TeacherPredmetRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
