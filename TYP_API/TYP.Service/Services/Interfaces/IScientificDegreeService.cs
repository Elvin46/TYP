using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.ScientificDegreeDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IScientificDegreeService
    {
        Task CreateAsync(ScientificDegreePostDTO scientificDegreeDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<ScientificDegreeGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<ScientificDegreeGetAllDTO> GetAllAsync();
        Task EditAsync(int id, ScientificDegreePostDTO scientificDegreeDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
