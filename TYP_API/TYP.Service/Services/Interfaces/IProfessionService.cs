using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.ProfessionDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IProfessionService
    {
        Task CreateAsync(ProfessionPostDTO professionDTO);
        Task<ProfessionGetDTO> GetByIdAsync(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<ProfessionGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<ProfessionGetAllDTO> GetAllAsync();
        Task EditAsync(int id, ProfessionPostDTO professionDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
