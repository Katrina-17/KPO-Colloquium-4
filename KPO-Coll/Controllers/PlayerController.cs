using KPO_Coll.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPO_Coll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet("players/{id}")]
        public IActionResult GetPlayer(int id)
        {
            try
            {
                var players = DBSimulator.GetPlayers();

                var res = (from p in players
                           where p.Id == id
                           select p).ToArray();

                if (res == null || res.Length == 0)
                {
                    return new NotFoundResult();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Неизвестная ощибка." });
            }
        }


        [HttpPost("players")]
        public IActionResult AddPlayer()
        {
            try
            {
                DBSimulator.AddPlayer(new Player());
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Неизвестная ошибка." });
            }
        }
    }
}
