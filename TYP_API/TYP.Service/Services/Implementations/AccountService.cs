using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RMS.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities.Autentication;
using TYP.Service.DTOs.AccountDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.Service.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task Delete(string username)
        {
            var existUser = await _userManager.FindByNameAsync(username);
            await _userManager.DeleteAsync(existUser);
        }

        public Task EditUserAsync(RegisterDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByNameAsync(string username)
        {
            var existUser = await _userManager.FindByNameAsync(username);
            if (existUser == null)
            {
                throw new NotFoundException("Invalid Username or Password");
            }
            UserDTO user = _mapper.Map<UserDTO>(existUser);
            return user;
        }

        public async Task RegisterAsync(RegisterDTO user)
        {
            var existUser = await _userManager.FindByNameAsync(user.Username);
            if (existUser != null)
            {
                throw new AlreadyExistException("This Username already exist");
            }
            var entity = new User
            {
                UserName = user.Username,
                DepartmentId = user.DepartmentId

            };
            var result = await _userManager.CreateAsync(entity, user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception(error.Description);
                }
            }
            await _userManager.AddToRoleAsync(entity, user.Role);
        }
        public async Task SignInAsync(SignInDTO user)
        {
            var existUser = await _userManager.FindByNameAsync(user.Username);
            if (existUser == null)
            {
                throw new NotFoundException("Invalid Username or Password");
            }
            var result = await _signInManager.PasswordSignInAsync(existUser, user.Password,true, true);
            if (result.IsLockedOut)
            {
                throw new Exception("This user is locked out");

            }
            if (!result.Succeeded)
            {
                throw new Exception("Invalid Username or Password");
            }
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task CheckDepartment(string username,int id)
        {
            var existUser = await _userManager.FindByNameAsync(username);
            if (existUser.DepartmentId != id)
            {
                throw new Exception("Suspicious Request Attempt!");
            }
        }
    }
}
