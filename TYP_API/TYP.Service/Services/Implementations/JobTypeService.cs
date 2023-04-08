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
using TYP.Service.DTOs.JobTypeDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(JobTypePostDTO JobTypeDTO)
        {
            if (await _unitOfWork.JobTypeRepository.IsExistAsync(x => x.Name == JobTypeDTO.Name))
                throw new AlreadyExistException($"{JobTypeDTO.Name} is already exist. Please change name!");
            JobType jobType = _mapper.Map<JobType>(JobTypeDTO);
            await _unitOfWork.JobTypeRepository.InsertAsync(jobType);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            JobType JobType = await _unitOfWork.JobTypeRepository.GetAsync(x => x.Id == id);
            if (JobType == null)
            {
                throw new NotFoundException("JobType doesn't exist in this Id");
            }
            JobType.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, JobTypePostDTO JobTypeDTO)
        {
            JobType JobType = await _unitOfWork.JobTypeRepository.GetAsync(x => x.Id == id);
            if (JobType == null)
            {
                throw new NotFoundException("JobType doesn't exist in this Id");
            }
            if (await _unitOfWork.JobTypeRepository.IsExistAsync(x => x.Id != id && x.Name == JobTypeDTO.Name))
            {
                throw new AlreadyExistException($"{JobTypeDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<JobTypePostDTO, JobType>(JobTypeDTO, JobType);
            await _unitOfWork.CommitAsync();
        }

        public async Task<JobTypeGetAllDTO> GetAllAsync()
        {
            List<JobType> entities = await _unitOfWork.JobTypeRepository.GetAllAsync(x => x.IsDeleted == false, "Teachers");
            List<JobTypeGetDTO> JobTypes = new List<JobTypeGetDTO>();
            foreach (var item in entities)
            {
                JobTypes.Add(_mapper.Map<JobTypeGetDTO>(item));
            }
            int count = await _unitOfWork.JobTypeRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            JobTypeGetAllDTO JobTypeGetAll = new JobTypeGetAllDTO
            {
                JobTypes = JobTypes,
                Count = count
            };
            return JobTypeGetAll;
        }

        public async Task<PagenatedListDTO<JobTypeGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<JobType> JobTypes = await _unitOfWork.JobTypeRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Teachers");
            if (search.Length == 0)
            {
                JobTypes = await _unitOfWork.JobTypeRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<JobTypeGetDTO> JobTypesListDto = new List<JobTypeGetDTO>();
            foreach (var item in JobTypes)
            {
                _mapper.Map<JobTypeGetDTO>(item);
                JobTypesListDto.Add(_mapper.Map<JobTypeGetDTO>(item));
            }
            int count = await _unitOfWork.JobTypeRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<JobTypeGetDTO> pagenatedJobTypes = new PagenatedListDTO<JobTypeGetDTO>(JobTypesListDto, page, count, pageSize);
            return pagenatedJobTypes;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            JobType JobType = await _unitOfWork.JobTypeRepository.GetAsync(x => x.Id == id, "Teachers");
            if (JobType == null) throw new Exception("JobType doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(JobType);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            JobType JobType = await _unitOfWork.JobTypeRepository.GetAsync(x => x.Name == name);
            if (JobType == null) throw new Exception("JobType doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(JobType);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.JobTypeRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
