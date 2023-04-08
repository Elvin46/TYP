using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.AccountDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _AccountService;

        public AccountController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            await _AccountService.RegisterAsync(user);
            return Ok();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDTO user)
        {
            await _AccountService.SignInAsync(user);
            return Ok();
        }
    }
}
