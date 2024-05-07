using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerminaldotNET.Data;

namespace TerminaldotNET.Controllers
{
    [ApiController]
    [Route("files")]
    public class ArchiveController : ControllerBase
    {
        
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
           var archives = await context
           .Archives
           .AsNoTracking()
           .ToListAsync();

           return Ok(archives); 
        }
    }
}