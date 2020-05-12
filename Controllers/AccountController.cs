using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

using Album_Web.Entities;
using Album_Web.Models;
using Album_Web.Utils;
using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Album_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly SignInManager<UserEntity> signInManager;
        private readonly IMapper mapper;
        public AccountController(UserManager<UserEntity> userManager
            , SignInManager<UserEntity> signInManager
            , IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost(Name = nameof(Login)), Route("login")]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            var user = await userManager.FindByNameAsync(userModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError("errMsg", "用户名或密码不正确");
                return NotFound(ModelState);
            }
            var signInRes = await signInManager.PasswordSignInAsync(user, userModel.Password, false, false);
            userModel.AccessToken = GenerateJwtToken.GetJwtToken(user);
            if (signInRes.Succeeded)
            {
                Response.Headers.Add("access_token", userModel.AccessToken);
                return Ok(userModel);
            }
            ModelState.AddModelError("errMsg", "用户名或密码不正确");
            return NotFound(ModelState);
        }

        [HttpPost(Name = nameof(Register)), Route("register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            var nameRes = await userManager.FindByNameAsync(userModel.UserName);
            if (nameRes != null)
            {
                ModelState.AddModelError("errMsg", "用户名已存在");
                return Conflict(ModelState);
            }
            var emailRes = await userManager.FindByEmailAsync(userModel.Email);
            if (emailRes != null)
            {
                ModelState.AddModelError("errMsg", "邮箱已存在");
                return Conflict(ModelState);
            }
            var userEntity = mapper.Map<UserEntity>(userModel);
            var userRes = await userManager.CreateAsync(userEntity, userModel.Password);
            var claimRes = await userManager.AddClaimAsync(userEntity, new Claim(JwtRegisteredClaimNames.Sub, userEntity.UserName));
            if (userRes.Succeeded && claimRes.Succeeded)
            {
                var signInRes = await signInManager.PasswordSignInAsync(userEntity, userModel.Password, false, false);
                if (signInRes.Succeeded)
                    return Ok();
            }
            return Problem();
        }

        [HttpHead, Authorize, Route("verthen")]
        public IActionResult VerifyAuthen()
        {
            return Ok();
        }
    }
}