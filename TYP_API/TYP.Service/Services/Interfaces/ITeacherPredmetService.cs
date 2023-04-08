using RMS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.DTOs.TeacherPredmetDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface ITeacherPredmetService
    {
        Task CreateAsync(TeacherPredmetPostDTO TeacherPredmetDTO);
        Task<TEntity> GetByIdAsync<TEntity>(int id);
        Task<TEntity> GetAsync<TEntity>(int TeacherId, int PredmetGroupId);
        Task<PagenatedListDTO<TeacherPredmetGetDTO>> GetAllFilteredAsync(int page, int pageSize, string search = "");
        Task<List<PredmetGroupGetDTO>> GetAllAsync(int teacherId);
        Task<TeacherPredmetPostViewDTO> GetAllPredmetAsync(int teacherId);
        Task EditAsync(int id, TeacherPredmetPostDTO TeacherPredmetDTO);
        Task Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
