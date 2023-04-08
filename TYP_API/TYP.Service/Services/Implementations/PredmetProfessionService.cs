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
using TYP.Service.DTOs.PredmetProfessionDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class PredmetProfessionService : IPredmetProfessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PredmetProfessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(PredmetProfessionPostDTO PredmetProfessionDTO)
        {
            foreach (var Id in PredmetProfessionDTO.PredmetIds)
            {
                if (await _unitOfWork.PredmetProfessionRepository.IsExistAsync(x => x.PredmetId == Id && x.Profession.Id == PredmetProfessionDTO.ProfessionId))
                    throw new AlreadyExistException($"This Predmet is already exist. Please change name!");
            }
            if (PredmetProfessionDTO.OutOfAuditoryHours + PredmetProfessionDTO.AuditoryHours != PredmetProfessionDTO.GeneralHours)
                throw new HoursDoesntMatchException($"Auditoriyadan Kenar saatlarla Auditoriya saatlarinin cemi Umumi saatlara beraber deyil. Yeniden Gozden Kecirin");
            if (PredmetProfessionDTO.Lecturer + PredmetProfessionDTO.Seminar + PredmetProfessionDTO.Laboratory != PredmetProfessionDTO.AuditoryHours)
                throw new HoursDoesntMatchException($"Muhazire,Seminar ve Laboratoriya saatlarinin cemi Umumi Auditoriya Saatlarina beraber deyil. Yeniden Gozden Kecirin");

            Profession profession = await _unitOfWork.ProfessionRepository.GetAsync(x => x.Id == PredmetProfessionDTO.ProfessionId);
            
            Random random = new Random();
            int orderby = random.Next(0, 1000);
            while (await _unitOfWork.PredmetProfessionRepository.IsExistAsync(x => x.orderBy == orderby))
            {
                orderby = random.Next(100000, 1000000);
            }
            
            for (int i = 0; i < PredmetProfessionDTO.PredmetIds.Count(); i++)
            {
                PredmetProfession predmetProfession = _mapper.Map<PredmetProfession>(PredmetProfessionDTO);
                if (PredmetProfessionDTO.CategoryId == 4 || PredmetProfessionDTO.CategoryId == 2)
                {
                    predmetProfession.orderBy = orderby;
                }
                predmetProfession.PredmetId = PredmetProfessionDTO.PredmetIds[i];
                predmetProfession.Code = PredmetProfessionDTO.Codes[i];
                await _unitOfWork.PredmetProfessionRepository.InsertAsync(predmetProfession);
                //if (profession.Groups.Count() != 0)
                //{
                //    foreach (var item in profession.Groups)
                //    {
                //        PredmetGroup predmetGroup = _mapper.Map<PredmetGroup>(predmetProfession);
                //        predmetGroup.GroupId = item.Id;
                //        await _unitOfWork.PredmetGroupRepository.InsertAsync(predmetGroup);
                //        await _unitOfWork.CommitAsync();

                //    }
                //}
                
                await _unitOfWork.CommitAsync();
            }

        }

        public async Task Delete(int id)
        {
            PredmetProfession PredmetProfession = await _unitOfWork.PredmetProfessionRepository.GetAsync(x => x.Id == id);
            if (PredmetProfession == null)
            {
                throw new NotFoundException("PredmetProfession doesn't exist in this Id");
            }
            PredmetProfession.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, PredmetProfessionPostDTO PredmetProfessionDTO)
        {
            PredmetProfession PredmetProfession = await _unitOfWork.PredmetProfessionRepository.GetAsync(x => x.Id == id);
            if (PredmetProfession == null)
            {
                throw new NotFoundException("PredmetProfession doesn't exist in this Id");
            }
            foreach (var item in PredmetProfessionDTO.PredmetIds)
            {
                if (await _unitOfWork.PredmetProfessionRepository.IsExistAsync(x => x.Id != id && x.PredmetId == item && x.Profession.Id == PredmetProfessionDTO.ProfessionId))
                    throw new AlreadyExistException($"This Predmet is already exist. Please change name!");

            }
            _mapper.Map<PredmetProfessionPostDTO, PredmetProfession>(PredmetProfessionDTO, PredmetProfession);
            await _unitOfWork.CommitAsync();
        }

        public async Task<PredmetProfessionGetAllDTO> GetAllAsync(int id)
        {
            List<PredmetProfession> entities = await _unitOfWork.PredmetProfessionRepository.GetAllAsync(x => x.IsDeleted == false && x.ProfessionId == id, "Predmet");
            List<PredmetProfessionGetDTO> PredmetProfessions = new List<PredmetProfessionGetDTO>();
            foreach (var item in entities)
            {
                PredmetProfessions.Add(_mapper.Map<PredmetProfessionGetDTO>(item));
            }
            int count = await _unitOfWork.PredmetProfessionRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PredmetProfessionGetAllDTO PredmetProfessionGetAll = new PredmetProfessionGetAllDTO
            {
                PredmetProfessions = PredmetProfessions,
                Count = count
            };
            return PredmetProfessionGetAll;
        }

        public async Task<PagenatedListDTO<PredmetProfessionGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<PredmetProfession> PredmetProfessions = await _unitOfWork.PredmetProfessionRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize);
            if (search.Length == 0)
            {
                PredmetProfessions = await _unitOfWork.PredmetProfessionRepository.GetAllPagenatedAsync(x => x.IsDeleted == false && x.Profession.Name.Contains(search), page, pageSize);
            }
            List<PredmetProfessionGetDTO> PredmetProfessionsListDto = new List<PredmetProfessionGetDTO>();
            foreach (var item in PredmetProfessions)
            {
                _mapper.Map<PredmetProfessionGetDTO>(item);
                PredmetProfessionsListDto.Add(_mapper.Map<PredmetProfessionGetDTO>(item));
            }
            int count = await _unitOfWork.PredmetProfessionRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<PredmetProfessionGetDTO> pagenatedPredmetProfessions = new PagenatedListDTO<PredmetProfessionGetDTO>(PredmetProfessionsListDto, page, count, pageSize);
            return pagenatedPredmetProfessions;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            PredmetProfession PredmetProfession = await _unitOfWork.PredmetProfessionRepository.GetAsync(x => x.Id == id);
            if (PredmetProfession == null) throw new Exception("PredmetProfession doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(PredmetProfession);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(string name)
        {
            PredmetProfession PredmetProfession = await _unitOfWork.PredmetProfessionRepository.GetAsync(x => x.Profession.Name == name);
            if (PredmetProfession == null) throw new Exception("PredmetProfession doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(PredmetProfession);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.PredmetProfessionRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
