using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fysio_API.Models;
using Fysio_API.Services;

namespace Fysio_API.Controllers
{
    public class DataController : Controller
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] Data data)
        {
            await _dataService.PutData(data);
            return Ok();
        }
    }
}
