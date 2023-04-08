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
using TYP.Service.DTOs.TeacherDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(TeacherPostDTO teacherDTO)
        {
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Name == teacherDTO.Name && x.Surname == teacherDTO.Surname))
                throw new AlreadyExistException($"{teacherDTO.Name} {teacherDTO.Surname} is already exist. Please change name!");
            List<int> placeIds = new List<int>();
            List<int> certificationIds = new List<int>();
            if (teacherDTO.Places != null || teacherDTO.Certifications != null)
            {
                foreach (var item in teacherDTO.Places)
                {
                    if (!await _unitOfWork.PlaceRepository.IsExistAsync(x => x.Name == item.PlaceName))
                    {
                        await _unitOfWork.PlaceRepository.InsertAsync(new Place
                        {
                            Name = item.PlaceName
                        });
                        await _unitOfWork.CommitAsync();
                    
                    }
                    var place = await _unitOfWork.PlaceRepository.GetAsync(x => x.Name == item.PlaceName);
                    placeIds.Add(place.Id);
                }
                foreach (var item in teacherDTO.Certifications)
                {
                    if (!await _unitOfWork.CertificationRepository.IsExistAsync(x => x.Name == item.Name))
                    {
                        await _unitOfWork.CertificationRepository.InsertAsync(new Certification
                        {
                            Name = item.Name,
                            IsLocal = item.IsLocal,
                            Country = item.Country
                        });
                        await _unitOfWork.CommitAsync();

                    }
                    var certification = await _unitOfWork.CertificationRepository.GetAsync(x => x.Name == item.Name);
                    certificationIds.Add(certification.Id);
                }
            }
            Teacher teacher = _mapper.Map<Teacher>(teacherDTO);
            await _unitOfWork.TeacherRepository.InsertAsync(teacher);
            await _unitOfWork.CommitAsync();
            var teacherEntity = await _unitOfWork.TeacherRepository.GetAsync(x=>x.Name == teacherDTO.Name);
            if (teacherDTO.Places != null || teacherDTO.Certifications != null || teacherDTO.Books != null || teacherDTO.Sectors != null)
            {
                foreach (var item in placeIds)
                {
                    await _unitOfWork.TeacherPlaceRepository.InsertAsync(new TeacherPlace
                    {
                        TeacherId = teacherEntity.Id,
                        PlaceId = item
                    });
                }
                foreach (var item in certificationIds)
                {
                    await _unitOfWork.TeacherCertificationRepository.InsertAsync(new TeacherCertification
                    {
                        TeacherId = teacherEntity.Id,
                        CertificationId = item
                    });
                }
                foreach (var item in teacherDTO.Sectors)
                {
                        if (await _unitOfWork.TeacherSectorRepository.IsExistAsync(x=>x.Level == item.Level && x.TeacherId == teacherEntity.Id))
                        {
                            throw new Exception("Teacher has this level sector");

                        }
                        else
                        {
                            await _unitOfWork.TeacherSectorRepository.InsertAsync(new TeacherSector
                            {
                                TeacherId = teacherEntity.Id,
                                SectorId = item.Id,
                                Level = item.Level

                            });
                        }
                    
                }
            }
            await _unitOfWork.CommitAsync();
        }
        public async Task Delete(int id)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == id);
            if (teacher == null)
            {
                throw new NotFoundException("Teacher doesn't exist in this Id");
            }
            teacher.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }
        public async Task EditAsync(int id, TeacherPostDTO teacherDTO)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == id);
            if (teacher == null)
            {
                throw new Exception("Teacher doesn't exist in this Id");
            }
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Id != id && x.Name == teacherDTO.Name))
            {
                throw new Exception("Teacher is Already Exist with this Name");
            }
            _mapper.Map<TeacherPostDTO, Teacher>(teacherDTO, teacher);

            await _unitOfWork.CommitAsync();
        }
        public async Task<TeacherGetAllDTO> GetAllAsync()
        {
            List<Teacher> entities = await _unitOfWork.TeacherRepository.GetAllAsync(x => x.IsDeleted == false, "Sex", "Department", "ScientificName", "ScientificDegree", "JobType");
            List<TeacherGetDTO> teachers = new List<TeacherGetDTO>();
            foreach (var item in entities)
            {
                teachers.Add(_mapper.Map<TeacherGetDTO>(item));
            }
            int count = await _unitOfWork.TeacherRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            TeacherGetAllDTO TeachersGetAll = new TeacherGetAllDTO
            {
                Teachers = teachers,
                Count = count
            };
            return TeachersGetAll;
        }
        public async Task<PagenatedListDTO<TeacherGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Teacher> teachers = await _unitOfWork.TeacherRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Sex", "Department", "ScientificName", "ScientificDegree", "JobType");
            if (search.Length == 0)
            {
                teachers = await _unitOfWork.TeacherRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<TeacherGetDTO> teachersListDto = new List<TeacherGetDTO>();
            foreach (var item in teachers)
            {
                _mapper.Map<TeacherGetDTO>(item);
                teachersListDto.Add(_mapper.Map<TeacherGetDTO>(item));
            }
            int count = await _unitOfWork.TeacherRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<TeacherGetDTO> pagenatedTeachers = new PagenatedListDTO<TeacherGetDTO>(teachersListDto, page, count, pageSize);
            return pagenatedTeachers;
        }
        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Id == id, "Sex", "Department", "ScientificName", "ScientificDegree", "JobType");
            if (teacher == null) throw new Exception("Teacher doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(teacher);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetAsync(x => x.Name == name, "Sex", "Department", "ScientificName", "ScientificDegree", "JobType");
            if (teacher == null) throw new Exception("Teacher doesn't exist in this name");

            TEntity entity = _mapper.Map<TEntity>(teacher);
            return entity;
        }
        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
