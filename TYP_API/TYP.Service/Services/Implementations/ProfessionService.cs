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
using TYP.Service.DTOs.ProfessionDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class ProfessionService : IProfessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProfessionPostDTO ProfessionDTO)
        {
            if (await _unitOfWork.ProfessionRepository.IsExistAsync(x => x.Name == ProfessionDTO.Name))
                throw new AlreadyExistException($"{ProfessionDTO.Name} is already exist. Please change name!");
            Profession profession = _mapper.Map<Profession>(ProfessionDTO);
            await _unitOfWork.ProfessionRepository.InsertAsync(profession);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Profession Profession = await _unitOfWork.ProfessionRepository.GetAsync(x => x.Id == id);
            if (Profession == null)
            {
                throw new NotFoundException("Profession doesn't exist in this Id");
            }
            Profession.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, ProfessionPostDTO ProfessionDTO)
        {
            Profession Profession = await _unitOfWork.ProfessionRepository.GetAsync(x => x.Id == id);
            if (Profession == null)
            {
                throw new NotFoundException("Profession doesn't exist in this Id");
            }
            if (await _unitOfWork.ProfessionRepository.IsExistAsync(x => x.Id != id && x.Name == ProfessionDTO.Name))
            {
                throw new AlreadyExistException($"{ProfessionDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<ProfessionPostDTO, Profession>(ProfessionDTO, Profession);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ProfessionGetAllDTO> GetAllAsync()
        {
            List<Profession> entities = await _unitOfWork.ProfessionRepository.GetAllAsync(x => x.IsDeleted == false, "Faculty");
            List<ProfessionGetDTO> Professions = new List<ProfessionGetDTO>();
            foreach (var item in entities)
            {
                Professions.Add(_mapper.Map<ProfessionGetDTO>(item));
            }
            int count = await _unitOfWork.ProfessionRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            ProfessionGetAllDTO ProfessionGetAll = new ProfessionGetAllDTO
            {
                Professions = Professions,
                Count = count
            };
            return ProfessionGetAll;
        }

        public async Task<PagenatedListDTO<ProfessionGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Profession> Professions = await _unitOfWork.ProfessionRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Faculty");
            if (search.Length == 0)
            {
                Professions = await _unitOfWork.ProfessionRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<ProfessionGetDTO> ProfessionsListDto = new List<ProfessionGetDTO>();
            foreach (var item in Professions)
            {
                _mapper.Map<ProfessionGetDTO>(item);
                ProfessionsListDto.Add(_mapper.Map<ProfessionGetDTO>(item));
            }
            int count = await _unitOfWork.ProfessionRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<ProfessionGetDTO> pagenatedProfessions = new PagenatedListDTO<ProfessionGetDTO>(ProfessionsListDto, page, count, pageSize);
            return pagenatedProfessions;
        }

        public async Task<ProfessionGetDTO> GetByIdAsync(int id)
        {
            Profession Profession = await _unitOfWork.ProfessionRepository.GetAsync(x => x.Id == id, "Faculty","PredmetProfessions.Predmet", "PredmetProfessions.Session");
            if (Profession == null) throw new Exception("Profession doesn't exist in this Id");
            List<int> orderBys = new List<int>(); 
            foreach (var item in Profession.PredmetProfessions)
            {
                if (item.orderBy !=null || item.orderBy != 0)
                {
                    if (!orderBys.Contains(item.orderBy))
                    {
                        orderBys.Add(item.orderBy);
                    }
                }
            }
            ProfessionGetDTO entity = _mapper.Map<ProfessionGetDTO>(Profession);
            entity.OrderBys = orderBys;
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            Profession Profession = await _unitOfWork.ProfessionRepository.GetAsync(x => x.Name == name, "Faculty");
            if (Profession == null) throw new Exception("Profession doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Profession);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.ProfessionRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
