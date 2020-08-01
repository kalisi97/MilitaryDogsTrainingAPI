using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using MilitaryDogsTrainingAPI.Models;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MilitaryDogsTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly ITrainingCourseService trainingCourseService;
        public AuthenticateController(ITrainingCourseService trainingCourseService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.trainingCourseService = trainingCourseService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //pokusava da nadje korisnika
            var user = await userManager.FindByNameAsync(model.Username);
            //ukoliko je korisnik nadjen i password je ok
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                //trazi sve uloge ovog korisnika
                var userRoles = await userManager.GetRolesAsync(user);
                //kreira novu listu Claims koja sadrzi dva Claim-a: 
                var authClaims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                //ovde dodaje Claimove koje ima rola 
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                //generise sign in kljuc
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                //generise token
                
                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                    
                //kaze okej
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
                
              
            }
            return Unauthorized();

        }

        [HttpPost]
        [Route("InstructorRegistration")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register([FromBody] RegisterInstructorModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.Username);
            if (userExist != null) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });
            string name = model.TrainingCourse;
            TrainingCourse trainingCourse = trainingCourseService.GetBy(t => t.Name == name);
            Instructor user = new Instructor()
            {
                Email = model.Email,
                UserName = model.Username,
                Rank = model.Rank,
                PhoneNumber = model.PhoneNumber,
                TrainingCourse = trainingCourse,
                FullName = model.FullName
            };
            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Error while registering customer!" });
                await userManager.AddToRoleAsync(user, "instructor");
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok(new ResponseModel { Status = "Success", Message = "Instructor created successfully!" });
        }



        [HttpPost]
        [Route("AdminRegistration")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.Username);
            if (userExist != null) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });
            Admin user = new Admin()
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Error while registering customer!" });

            await userManager.AddToRoleAsync(user, "admin");

            return Ok(new ResponseModel { Status = "Success", Message = "Admin created successfully!" });
        }
        [HttpPost(Name = "SignOut")]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Ok(new ResponseModel { Status = "Success", Message = "User signed out successfully!" });
        }
    }
}
