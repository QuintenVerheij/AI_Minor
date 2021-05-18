using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fysio_API.Auth;
using Fysio_API.Dto;
using Fysio_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_API.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IFysioRepository _repo;

        public ClientController(UserManager<ApplicationUser> userManager, IFysioRepository repo)
        {
            _repo = repo;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.Client)]
        public string GetClient(string id)
        {
            return null; //_userManager.GetUserId(id);
        }

                     
                
    }
}