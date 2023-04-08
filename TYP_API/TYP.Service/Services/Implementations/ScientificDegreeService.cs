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
using TYP.Service.DTOs.ScientificDegreeDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class ScientificDegreeService : IScientificDegreeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScientificDegreeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(ScientificDegreePostDTO scientificDegreeDTO)
        {
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Name == scientificDegreeDTO.Name))
                throw new AlreadyExistException($"{scientificDegreeDTO.Name} is already exist. Please change name!");
            ScientificDegree scientificDegree = _mapper.Map<ScientificDegree>(scientificDegreeDTO);
            await _unitOfWork.ScientificDegreeRepository.InsertAsync(scientificDegree);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            ScientificDegree scientificDegree = await _unitOfWork.ScientificDegreeRepository.GetAsync(x => x.Id == id);
            if (scientificDegree == null)
            {
                throw new NotFoundException("Scientific Degree doesn't exist in this Id");
            }
            scientificDegree.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, ScientificDegreePostDTO scientificDegreeDTO)
        {
            ScientificDegree scientificDegree = await _unitOfWork.ScientificDegreeRepository.GetAsync(x => x.Id == id);
            if (scientificDegree == null)
            {
                throw new NotFoundException("Scientific Degree doesn't exist in this Id");
            }
            if (await _unitOfWork.TeacherRepository.IsExistAsync(x => x.Id != id && x.Name == scientificDegreeDTO.Name))
            {
                throw new AlreadyExistException($"{scientificDegreeDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<ScientificDegreePostDTO, ScientificDegree>(scientificDegreeDTO, scientificDegree);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ScientificDegreeGetAllDTO> GetAllAsync()
        {
            List<ScientificDegree> entities = await _unitOfWork.ScientificDegreeRepository.GetAllAsync(x => x.IsDeleted == false, "Teachers");
            List<ScientificDegreeGetDTO> scientificDegrees = new List<ScientificDegreeGetDTO>();
            foreach (var item in entities)
            {
                scientificDegrees.Add(_mapper.Map<ScientificDegreeGetDTO>(item));
            }
            int count = await _unitOfWork.ScientificDegreeRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            ScientificDegreeGetAllDTO ScientificDegreeGetAll = new ScientificDegreeGetAllDTO
            {
                ScientificDegrees = scientificDegrees,
                Count = count
            };
            return ScientificDegreeGetAll;
        }

        public async Task<PagenatedListDTO<ScientificDegreeGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<ScientificDegree> scientificDegrees = await _unitOfWork.ScientificDegreeRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Sex", "Department", "ScientificDegree", "ScientificDegree", "JobType");
            if (search.Length == 0)
            {
                scientificDegrees = await _unitOfWork.ScientificDegreeRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<ScientificDegreeGetDTO> teachersListDto = new List<ScientificDegreeGetDTO>();
            foreach (var item in scientificDegrees)
            {
                _mapper.Map<ScientificDegreeGetDTO>(item);
                teachersListDto.Add(_mapper.Map<ScientificDegreeGetDTO>(item));
            }
            int count = await _unitOfWork.ScientificDegreeRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<ScientificDegreeGetDTO> pagenatedscientificDegrees = new PagenatedListDTO<ScientificDegreeGetDTO>(teachersListDto, page, count, pageSize);
            return pagenatedscientificDegrees;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            ScientificDegree scientificDegree = await _unitOfWork.ScientificDegreeRepository.GetAsync(x => x.Id == id, "Teachers");
            if (scientificDegree == null) throw new Exception("Scientific Degree doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(scientificDegree);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            ScientificDegree scientificDegree = await _unitOfWork.ScientificDegreeRepository.GetAsync(x => x.Name == name);
            if (scientificDegree == null) throw new Exception("Scientific Degree doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(scientificDegree);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.ScientificDegreeRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
