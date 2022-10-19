using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           //IConfiguration configuration,
           IJwtService jwtService , IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            //_configuration = configuration;
            _jwtService = jwtService;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _userManager.Users;
        }

        public async Task<AuthenticateResultModel> Login(string username, string password)
        {
            //check if user exists
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (!result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Login failed!" }
                };
            }
            //user exists => generate token
            //get the claims
            var user = await _userManager.FindByNameAsync(username);
            var claims = (List<Claim>)await _userManager.GetClaimsAsync(user);
            //generate the token
            var token = _jwtService.GenerateToken(claims);
            //serializthe token
            var serializedToken = _jwtService.SerializeToken(token);
            //return the token
            return new AuthenticateResultModel { Success = true, Messages = new List<string> { serializedToken } };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string city, string addressLine, 
            string postalCode, DateTime DateOfBirth, string password)
        {
            //create a user
            var applicationUser = new ApplicationUser
            {
                Firstname = firstname,
                Lastname = lastname,
                UserName = username,
                Email = username,
                AddressLine = addressLine,
                PostalCode = postalCode,
                DateOfBirth = DateOfBirth,
                City = city
            };
            //store in database
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Registration failed!" }
                };
            }
            //get the user and add a claim registration-date
            applicationUser = await _userManager.FindByNameAsync(username);
            //add a claim registration-date
            await _userManager.AddClaimAsync(applicationUser,
                new Claim(ClaimTypes.Role , "customer"));
            return new AuthenticateResultModel
            {
                Success = true,
                Messages = new List<string> { "user registered!" }
            };

        }
    }
}
