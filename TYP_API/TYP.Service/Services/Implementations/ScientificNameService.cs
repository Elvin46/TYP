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
using TYP.Service.DTOs.ScientificNameDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class ScientificNameService : IScientificNameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScientificNameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(ScientificNamePostDTO ScientificNameDTO)
        {
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Name == ScientificNameDTO.Name))
                throw new AlreadyExistException($"{ScientificNameDTO.Name} is already exist. Please change name!");
            ScientificName ScientificName = _mapper.Map<ScientificName>(ScientificNameDTO);
            await _unitOfWork.ScientificNameRepository.InsertAsync(ScientificName);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            ScientificName ScientificName = await _unitOfWork.ScientificNameRepository.GetAsync(x => x.Id == id);
            if (ScientificName == null)
            {
                throw new NotFoundException("Scientific Name doesn't exist in this Id");
            }
            ScientificName.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, ScientificNamePostDTO ScientificNameDTO)
        {
            ScientificName ScientificName = await _unitOfWork.ScientificNameRepository.GetAsync(x => x.Id == id);
            if (ScientificName == null)
            {
                throw new NotFoundException("Scientific Name doesn't exist in this Id");
            }
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Id != id && x.Name == ScientificNameDTO.Name))
            {
                throw new AlreadyExistException($"{ScientificNameDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<ScientificNamePostDTO, ScientificName>(ScientificNameDTO, ScientificName);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ScientificNameGetAllDTO> GetAllAsync()
        {
            List<ScientificName> entities = await _unitOfWork.ScientificNameRepository.GetAllAsync(x => x.IsDeleted == false, "Teachers");
            List<ScientificNameGetDTO> ScientificNames = new List<ScientificNameGetDTO>();
            foreach (var item in entities)
            {
                ScientificNames.Add(_mapper.Map<ScientificNameGetDTO>(item));
            }
            int count = await _unitOfWork.ScientificNameRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            ScientificNameGetAllDTO ScientificNameGetAll = new ScientificNameGetAllDTO
            {
                ScientificNames = ScientificNames,
                Count = count
            };
            return ScientificNameGetAll;
        }

        public async Task<PagenatedListDTO<ScientificNameGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<ScientificName> ScientificNames = await _unitOfWork.ScientificNameRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Teachers");
            if (search.Length == 0)
            {
                ScientificNames = await _unitOfWork.ScientificNameRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<ScientificNameGetDTO> teachersListDto = new List<ScientificNameGetDTO>();
            foreach (var item in ScientificNames)
            {
                _mapper.Map<ScientificNameGetDTO>(item);
                teachersListDto.Add(_mapper.Map<ScientificNameGetDTO>(item));
            }
            int count = await _unitOfWork.ScientificNameRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<ScientificNameGetDTO> pagenatedScientificNames = new PagenatedListDTO<ScientificNameGetDTO>(teachersListDto, page, count, pageSize);
            return pagenatedScientificNames;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            ScientificName ScientificName = await _unitOfWork.ScientificNameRepository.GetAsync(x => x.Id == id, "Teachers");
            if (ScientificName == null) throw new Exception("Scientific Name doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(ScientificName);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            ScientificName ScientificName = await _unitOfWork.ScientificNameRepository.GetAsync(x => x.Name == name);
            if (ScientificName == null) throw new Exception("Scientific Name doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(ScientificName);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.ScientificNameRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
