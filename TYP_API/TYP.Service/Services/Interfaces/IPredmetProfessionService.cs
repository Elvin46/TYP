using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.PredmetProfessionDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IPredmetProfessionService
    {
        Task CreateAsync(PredmetProfessionPostDTO predmetProfessionDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<PredmetProfessionGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<PredmetProfessionGetAllDTO> GetAllAsync(int id);
        Task EditAsync(int id, PredmetProfessionPostDTO predmetProfessionDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
