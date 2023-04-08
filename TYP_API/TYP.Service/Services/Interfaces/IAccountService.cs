using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.AccountDTOs;

namespace TYP.Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterDTO user);
        Task SignInAsync(SignInDTO user);
        Task SignOutAsync();
        Task<UserDTO> GetByNameAsync(string username);
        Task<List<UserDTO>> GetAllAsync();
        Task EditUserAsync(RegisterDTO user);
        Task Delete(string username);
        Task CheckDepartment(string username, int id);
    }
}
