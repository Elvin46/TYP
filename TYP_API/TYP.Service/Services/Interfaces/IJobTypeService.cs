using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.JobTypeDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IJobTypeService
    {
        Task CreateAsync(JobTypePostDTO jobTypeDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetByNameAsync<TEntity>(string name);
        Task<PagenatedListDTO<JobTypeGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<JobTypeGetAllDTO> GetAllAsync();
        Task EditAsync(int id, JobTypePostDTO jobTypeDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
