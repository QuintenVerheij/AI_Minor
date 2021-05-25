using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fysio_API.Auth;
using Fysio_API.Helpers;
using Fysio_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fysio_API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UsersController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppSettings _appSettings;
        private PairingCodesHelper _pairingCodesHelper;
        private readonly FysioDbContext _fysioDbContext;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IOptions<AppSettings> appSettings, FysioDbContext fysioDbContext)
        {
            _userManager = userManager;
            roleManager = roleMgr;
            _appSettings = appSettings.Value;
            _fysioDbContext = fysioDbContext;
            _pairingCodesHelper = new PairingCodesHelper(fysioDbContext);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]AuthenticateModel model)
        {
            var appUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            await AssureRoles();
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, model.Role);

                if (model.Role == Role.Therapist)
                {
                    _pairingCodesHelper.New(appUser.Id);
                }
                return Ok(result);
            }

            return StatusCode(500, result);
        }

        private async Task AssureRoles()
        {
            var alreadyExistClient = await roleManager.RoleExistsAsync(Role.Client);
            var alreadyExistTherapist = await roleManager.RoleExistsAsync(Role.Therapist);

            if (!alreadyExistClient)
                await roleManager.CreateAsync(new IdentityRole(Role.Client));
            if (!alreadyExistTherapist)
                await roleManager.CreateAsync(new IdentityRole(Role.Therapist));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
        
    }
}