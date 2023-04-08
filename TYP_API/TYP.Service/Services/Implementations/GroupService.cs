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
using TYP.Service.DTOs.PredmetProfessionDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(GroupPostDTO GroupDTO)
        {
            if (await _unitOfWork.GroupRepository.IsExistAsync(x => x.Number == GroupDTO.Number))
                throw new AlreadyExistException($"{GroupDTO.Number} is already exist. Please change name!");
            List<PredmetProfession> predmetProfessions = await _unitOfWork.PredmetProfessionRepository.GetAllAsync(x => x.ProfessionId == GroupDTO.ProfessionId);
            Group group = _mapper.Map<Group>(GroupDTO);
            await _unitOfWork.GroupRepository.InsertAsync(group);
            await _unitOfWork.CommitAsync();
            group = await _unitOfWork.GroupRepository.GetAsync(x => x.Number == GroupDTO.Number);
            foreach (var item in predmetProfessions)
            {
                PredmetProfessionMapDTO predmetProfessionDTO = _mapper.Map<PredmetProfessionMapDTO>(item);
                PredmetGroup predmetGroup = _mapper.Map<PredmetGroup>(predmetProfessionDTO);
                predmetGroup.GroupId = group.Id;
                await _unitOfWork.PredmetGroupRepository.InsertAsync(predmetGroup);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            Group Group = await _unitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (Group == null)
            {
                throw new NotFoundException("Group doesn't exist in this Id");
            }
            Group.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(int id, GroupPostDTO GroupDTO)
        {
            Group Group = await _unitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (Group == null)
            {
                throw new NotFoundException("Group doesn't exist in this Id");
            }
            if (await _unitOfWork.GroupRepository.IsExistAsync(x => x.Id != id && x.Number == GroupDTO.Number))
            {
                throw new AlreadyExistException($"{GroupDTO.Number} is already exist. Please change name!");
            }
            _mapper.Map<GroupPostDTO, Group>(GroupDTO, Group);
            await _unitOfWork.CommitAsync();
        }

        public async Task<GroupGetAllDTO> GetAllAsync()
        {
            List<Group> entities = await _unitOfWork.GroupRepository.GetAllAsync(x => x.IsDeleted == false, "Profession.PredmetProfessions", "Sector");
            List<GroupGetDTO> Groups = new List<GroupGetDTO>();
            foreach (var item in entities)
            {
                Groups.Add(_mapper.Map<GroupGetDTO>(item));
            }
            int count = await _unitOfWork.GroupRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            GroupGetAllDTO GroupGetAll = new GroupGetAllDTO
            {
                Groups = Groups,
                Count = count
            };
            return GroupGetAll;
        }

        public async Task<PagenatedListDTO<GroupGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "")
        {
            List<Group> Groups = await _unitOfWork.GroupRepository.GetAllPagenatedAsync(x => x.IsDeleted == false, page, pageSize, "Profession.PredmetProfessions");
            if (search.Length == 0)
            {
                Groups = await _unitOfWork.GroupRepository.GetAllPagenatedAsync(x => x.IsDeleted == false /*&& x.Number.Contains(search)*/, page, pageSize);
            }
            List<GroupGetDTO> GroupsListDto = new List<GroupGetDTO>();
            foreach (var item in Groups)
            {
                _mapper.Map<GroupGetDTO>(item);
                GroupsListDto.Add(_mapper.Map<GroupGetDTO>(item));
            }
            int count = await _unitOfWork.GroupRepository.GetTotalCountAsync(x => x.IsDeleted == false);
            PagenatedListDTO<GroupGetDTO> pagenatedGroups = new PagenatedListDTO<GroupGetDTO>(GroupsListDto, page, count, pageSize);
            return pagenatedGroups;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
        {
            Group Group = await _unitOfWork.GroupRepository.GetAsync(x => x.Id == id, "Profession.PredmetProfessions");
            if (Group == null) throw new Exception("Group doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Group);
            return entity;
        }
        public async Task<TEntity> GetByNameAsync<TEntity>(int number)
        {
            Group Group = await _unitOfWork.GroupRepository.GetAsync(x => x.Number == number);
            if (Group == null) throw new Exception("Group doesn't exist in this Id");

            TEntity entity = _mapper.Map<TEntity>(Group);
            return entity;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            return await _unitOfWork.GroupRepository.IsExistAsync(x => x.Id == id);
        }
    }
}
