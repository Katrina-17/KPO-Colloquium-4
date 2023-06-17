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
    public class GameController : ControllerBase
    {
        [HttpGet("games/{id}")]
        public IActionResult GetGame(int id)
        {
            try
            {
                var games = DBSimulator.GetGames();

                var res = (from g in games
                           where g.Id == id
                           select g).ToArray();

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


        [HttpPost("games")]
        public IActionResult AddGame(int id1stPlayer, int id2ndPlayer)
        {
            try
            {
                var first = (from p in DBSimulator.GetPlayers()
                             where p.Id == id1stPlayer
                             select p).ToArray();
                var second = (from p in DBSimulator.GetPlayers()
                             where p.Id == id2ndPlayer
                             select p).ToArray();

                if (first.Length <= 0 || second.Length <= 0)
                {
                    return new NotFoundResult();
                }


                DBSimulator.AddGame(new Models.Game(id1stPlayer, id2ndPlayer));
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Неизвестная ошибка." });
            }
        }


        [HttpPut("games/{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameRequest gameRequest)
        {
            try
            {
                var games = DBSimulator.GetGames();

                var res = (from g in games
                           where g.Id == id
                           select g).ToArray();

                if (res == null || res.Length == 0)
                {
                    return new NotFoundResult();
                }
                else
                {
                    if (gameRequest.FirstPlayerPlusScore == 0 && gameRequest.SecondPlayerPlusScore == 0)
                    {
                        res[0].State = Game.GameState.Finished;
                        var first = (from player in DBSimulator.GetPlayers()
                                     where player.Id == res[0].Id1stPlayer
                                     select player).ToArray();

                        var second = (from player in DBSimulator.GetPlayers()
                                     where player.Id == res[0].Id2ndPlayer
                                     select player).ToArray();


                        if (res[0].Score1stPlayer > res[0].Score2ndPlayer)
                        {
                            first[0].AddVictory();
                            second[0].AddLoss();
                        }
                        else if (res[0].Score1stPlayer < res[0].Score2ndPlayer)
                        {
                            second[0].AddVictory();
                            first[0].AddLoss();
                        }


                        return Ok();
                    } 
                    else
                    {
                        res[0].Score1stPlayer += gameRequest.FirstPlayerPlusScore;
                        res[0].Score2ndPlayer += gameRequest.SecondPlayerPlusScore;
                    }

                    return Ok(res);
                }
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Неизвестная ошибка." });
            }
        }

    }
}
