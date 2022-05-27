﻿using HRIS.Domain.ViewModels;
using System.Threading.Tasks;

namespace HRIS.Web.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginRequest loginRequest);
        Task Logout();
        //Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
