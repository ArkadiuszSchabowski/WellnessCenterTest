﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SpaSalon.Database.Entities;
using SpaSalon.Models;
using SpaSalon.Services;

namespace SpaSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            _service.GenerateJWT(dto);
            return Ok();
        }
        [HttpPost("registration")]
        public ActionResult Registration([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);
            return Ok();
        }
        [HttpGet]
        public ActionResult GetAll() 
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {
            _service.RemoveUser(id);
            return Ok();
        }
    }
}