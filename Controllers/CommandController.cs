using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerminaldotNET.Data;
using TerminaldotNET.ViewModels;


namespace TerminaldotNET.Controllers
{
    [ApiController]
    [Route("input")]
    public class CommandController : ControllerBase
    {
        
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context, 
            [FromBody] SearchCommandViewModel model)
        {
            var command = await context
            .Commands
            .FirstOrDefaultAsync(x => x.Call == model.Call);

            if (command == null)
                return NotFound();

            try
            {
                var response = new {
                    command.Output,
                    command.Execute
                };
                
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            
        }
    }
}