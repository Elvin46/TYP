using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.SectorDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface ISectorService
    {
        Task CreateAsync(SectorPostDTO SectorDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<SectorGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<SectorGetAllDTO> GetAllAsync();
        Task EditAsync(int id, SectorPostDTO SectorDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
