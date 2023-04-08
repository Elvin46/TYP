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
using TYP.Service.DTOs.PredmetDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class PredmetService : IPredmetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PredmetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(PredmetPostDTO PredmetDTO)
        {
            if (await _unitOfWork.PredmetRepository.IsExistAsync(x => x.Name == PredmetDTO.Name))
                throw new AlreadyExistException($"{PredmetDTO.Name} is already exist. Please change name!");
            Predmet predmet = _mapper.Map<Predmet>(PredmetDTO);
            await _unitOfWork.PredmetRepository.InsertAsync(predmet);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Predmet Predmet = await _unitOfWork.PredmetRepository.GetAsync(x => x.Id == id);
            if (Predmet == null)
            {
                throw new NotFoundException("Predmet doesn't exist in this Id");
            }
            Predmet.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, PredmetPostDTO PredmetDTO)
        {
            Predmet Predmet = await _unitOfWork.PredmetRepository.GetAsync(x => x.Id == id);
            if (Predmet == null)
            {
                throw new NotFoundException("Predmet doesn't exist in this Id");
            }
            if (await _unitOfWork.PredmetRepository.IsExistAsync(x => x.Id != id && x.Name == PredmetDTO.Name))
            {
                throw new AlreadyExistException($"{PredmetDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<PredmetPostDTO, Predmet>(PredmetDTO, Predmet);
            await _unitOfWork.CommitAsync();
        }

        public async Task<PredmetGetAllDTO> GetAllAsync()
        {
            List<Predmet> entities = await _unitOfWork.PredmetRepository.GetAllAsync(x => x.IsDeleted == false);
            entities.OrderBy(x => x.Name);
            List<PredmetGetDTO> Predmets = new List<PredmetGetDTO>();
            foreach (var item in entities)
            {
                Predmets.Add(_mapper.Map<PredmetGetDTO>(item));
            }
            int count = await _unitOfWork.PredmetRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PredmetGetAllDTO PredmetGetAll = new PredmetGetAllDTO
            {
                Predmets = Predmets,
                Count = count
            };
            return PredmetGetAll;
        }

        public async Task<PagenatedListDTO<PredmetGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Predmet> Predmets = await _unitOfWork.PredmetRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize);
            if (search.Length == 0)
            {
                Predmets = await _unitOfWork.PredmetRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<PredmetGetDTO> PredmetsListDto = new List<PredmetGetDTO>();
            foreach (var item in Predmets)
            {
                _mapper.Map<PredmetGetDTO>(item);
                PredmetsListDto.Add(_mapper.Map<PredmetGetDTO>(item));
            }
            int count = await _unitOfWork.PredmetRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<PredmetGetDTO> pagenatedPredmets = new PagenatedListDTO<PredmetGetDTO>(PredmetsListDto, page, count, pageSize);
            return pagenatedPredmets;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            Predmet Predmet = await _unitOfWork.PredmetRepository.GetAsync(x => x.Id == id);
            if (Predmet == null) throw new Exception("Predmet doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Predmet);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            Predmet Predmet = await _unitOfWork.PredmetRepository.GetAsync(x => x.Name == name);
            if (Predmet == null) throw new Exception("Predmet doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Predmet);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.PredmetRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
