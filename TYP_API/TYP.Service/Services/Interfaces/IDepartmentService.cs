using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateAsync(DepartmentPostDTO departmentDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<DepartmentGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<DepartmentGetAllDTO> GetAllAsync();
        Task EditAsync(int id, DepartmentPostDTO departmentDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
