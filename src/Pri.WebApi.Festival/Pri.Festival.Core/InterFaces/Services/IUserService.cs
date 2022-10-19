using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> Login(string username, string password);
        Task Logout();
        Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string city , string addressLine ,  string postalCode 
            , DateTime DateOfBirth, string password );
        IQueryable<ApplicationUser> GetUsers();
      

    }
}
