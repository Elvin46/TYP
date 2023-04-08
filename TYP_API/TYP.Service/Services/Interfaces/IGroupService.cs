using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.GroupDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(GroupPostDTO GroupDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(int number);
        Task<PagenatedListDTO<GroupGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<GroupGetAllDTO> GetAllAsync();
        Task EditAsync(int id, GroupPostDTO GroupDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
