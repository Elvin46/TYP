using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.PredmetDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IPredmetService
    {
        Task CreateAsync(PredmetPostDTO predmetDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<PredmetGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<PredmetGetAllDTO> GetAllAsync();
        Task EditAsync(int id, PredmetPostDTO predmetDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
