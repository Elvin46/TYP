using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.ScientificNameDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IScientificNameService
    {
        Task CreateAsync(ScientificNamePostDTO scientificNameDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<ScientificNameGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<ScientificNameGetAllDTO> GetAllAsync();
        Task EditAsync(int id, ScientificNamePostDTO scientificNameDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
