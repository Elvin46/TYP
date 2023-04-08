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
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(DepartmentPostDTO DepartmentDTO)
        {
            if (await _unitOfWork.DepartmentRepository.IsExistAsync(x => x.Name == DepartmentDTO.Name))
                throw new AlreadyExistException($"{DepartmentDTO.Name} is already exist. Please change name!");
            Department Department = _mapper.Map<Department>(DepartmentDTO);
            await _unitOfWork.DepartmentRepository.InsertAsync(Department);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Department Department = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id);
            if (Department == null)
            {
                throw new NotFoundException("Department doesn't exist in this Id");
            }
            Department.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, DepartmentPostDTO DepartmentDTO)
        {
            Department Department = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id);
            if (Department == null)
            {
                throw new NotFoundException("Department doesn't exist in this Id");
            }
            if (await _unitOfWork.DepartmentRepository.IsExistAsync(x => x.Id != id && x.Name == DepartmentDTO.Name))
            {
                throw new AlreadyExistException($"{DepartmentDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<DepartmentPostDTO, Department>(DepartmentDTO, Department);
            await _unitOfWork.CommitAsync();
        }

        public async Task<DepartmentGetAllDTO> GetAllAsync()
        {
            List<Department> entities = await _unitOfWork.DepartmentRepository.GetAllAsync(x => x.IsDeleted == false, "Teachers");
            List<DepartmentGetDTO> Departments = new List<DepartmentGetDTO>();
            foreach (var item in entities)
            {
                Departments.Add(_mapper.Map<DepartmentGetDTO>(item));
            }
            int count = await _unitOfWork.DepartmentRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            DepartmentGetAllDTO DepartmentGetAll = new DepartmentGetAllDTO
            {
                Departments = Departments,
                Count = count
            };
            return DepartmentGetAll;
        }

        public async Task<PagenatedListDTO<DepartmentGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Department> Departments = await _unitOfWork.DepartmentRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Teachers");
            if (search.Length == 0)
            {
                Departments = await _unitOfWork.DepartmentRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<DepartmentGetDTO> DepartmentsListDto = new List<DepartmentGetDTO>();
            foreach (var item in Departments)
            {
                _mapper.Map<DepartmentGetDTO>(item);
                DepartmentsListDto.Add(_mapper.Map<DepartmentGetDTO>(item));
            }
            int count = await _unitOfWork.DepartmentRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<DepartmentGetDTO> pagenatedDepartments = new PagenatedListDTO<DepartmentGetDTO>(DepartmentsListDto, page, count, pageSize);
            return pagenatedDepartments;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            Department Department = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id, "Teachers");
            if (Department == null) throw new Exception("Department doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Department);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            Department Department = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Name == name);
            if (Department == null) throw new Exception("Department doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Department);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.DepartmentRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
