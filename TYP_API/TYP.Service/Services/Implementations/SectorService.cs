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
using TYP.Service.DTOs.SectorDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class SectorService : ISectorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SectorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(SectorPostDTO SectorDTO)
        {
            if (await _unitOfWork.SectorRepository.IsExistAsync(x => x.Name == SectorDTO.Name))
                throw new AlreadyExistException($"{SectorDTO.Name} is already exist. Please change name!");
            Sector sector = _mapper.Map<Sector>(SectorDTO);
            await _unitOfWork.SectorRepository.InsertAsync(sector);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Sector Sector = await _unitOfWork.SectorRepository.GetAsync(x => x.Id == id);
            if (Sector == null)
            {
                throw new NotFoundException("Sector doesn't exist in this Id");
            }
            Sector.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, SectorPostDTO SectorDTO)
        {
            Sector Sector = await _unitOfWork.SectorRepository.GetAsync(x => x.Id == id);
            if (Sector == null)
            {
                throw new NotFoundException("Sector doesn't exist in this Id");
            }
            if (await _unitOfWork.SectorRepository.IsExistAsync(x => x.Id != id && x.Name == SectorDTO.Name))
            {
                throw new AlreadyExistException($"{SectorDTO.Name} is already exist. Please change name!");
            }
            _mapper.Map<SectorPostDTO, Sector>(SectorDTO, Sector);
            await _unitOfWork.CommitAsync();
        }

        public async Task<SectorGetAllDTO> GetAllAsync()
        {
            List<Sector> entities = await _unitOfWork.SectorRepository.GetAllAsync(x => x.IsDeleted == false);
            List<SectorGetDTO> Sectors = new List<SectorGetDTO>();
            foreach (var item in entities)
            {
                Sectors.Add(_mapper.Map<SectorGetDTO>(item));
            }
            int count = await _unitOfWork.SectorRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            SectorGetAllDTO SectorGetAll = new SectorGetAllDTO
            {
                Sectors = Sectors,
                Count = count
            };
            return SectorGetAll;
        }

        public async Task<PagenatedListDTO<SectorGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Sector> Sectors = await _unitOfWork.SectorRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize);
            if (search.Length == 0)
            {
                Sectors = await _unitOfWork.SectorRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Name.Contains(search), page, pageSize);
            }
            List<SectorGetDTO> SectorsListDto = new List<SectorGetDTO>();
            foreach (var item in Sectors)
            {
                _mapper.Map<SectorGetDTO>(item);
                SectorsListDto.Add(_mapper.Map<SectorGetDTO>(item));
            }
            int count = await _unitOfWork.SectorRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<SectorGetDTO> pagenatedSectors = new PagenatedListDTO<SectorGetDTO>(SectorsListDto, page, count, pageSize);
            return pagenatedSectors;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            Sector Sector = await _unitOfWork.SectorRepository.GetAsync(x => x.Id == id);
            if (Sector == null) throw new Exception("Sector doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Sector);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            Sector Sector = await _unitOfWork.SectorRepository.GetAsync(x => x.Name == name);
            if (Sector == null) throw new Exception("Sector doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Sector);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.SectorRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
