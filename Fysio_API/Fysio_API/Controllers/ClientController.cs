using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fysio_API.Dto;
using Fysio_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_API.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IFysioRepository _fysioRepository;
        private readonly IMapper _mapper;
        public ClientController(IFysioRepository fysioRepository, IMapper mapper)
        {
            _fysioRepository = fysioRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public void AddClient([FromBody]ClientDto_In clientIn)
        {
            Client client = _mapper.Map<Client>(clientIn);
            _fysioRepository.AddClient(client);
        }

        [HttpGet("{clientId}")]
        public IActionResult GetClient(int clientId)
        {
            Client resClient = _fysioRepository.GetClient(clientId);
            if (resClient == null)
                return NotFound();
            else
                return new JsonResult(resClient);
        }
    }
}