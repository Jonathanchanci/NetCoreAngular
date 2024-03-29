﻿using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.Models;
using NetCoreAngular.UnitOfWork;
using NetCoreAngular.WebApi.Autenticacion;
using System;

namespace NetCoreAngular.WebApi.Controllers
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private ITokenLogic _logic;

        public TokenController(ITokenProvider tokenProvider, ITokenLogic logic)
        {
            _tokenProvider = tokenProvider;
            _logic = logic;
        }

        public JsonWebToken Post([FromBody] User userLogin)
        {
            var user = _logic.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480//minutos
            };
            return token;
        }
    }
}