using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.TeacherDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface ITeacherService
    {
        Task CreateAsync(TeacherPostDTO teacherDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<TeacherGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<TeacherGetAllDTO> GetAllAsync();
        Task EditAsync(int id, TeacherPostDTO teacherDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
