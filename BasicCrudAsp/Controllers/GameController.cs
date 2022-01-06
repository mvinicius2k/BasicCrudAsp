using BasicCrudAsp.Models;
using BasicCrudAsp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrudAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// Instância para o BD
        /// </summary>
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll() => _gameService.GetAll();
        
        [HttpGet("{id:length(24)}", Name = "GetGame")]
        public ActionResult<Game> Get(string id)
        {
            var game =_gameService.Get(id);
            if (game is null)
                return NotFound();
            else
                return game;
                
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
           _gameService.Add(game);
            return CreatedAtAction(nameof(Create), new { id = game.Id }, game);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, Game game)
        {
            if (id != game.Id)
                return BadRequest();
            var gameFromDb =_gameService.Get(id);
            if(gameFromDb is not null)
            {
               _gameService.Update(game);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var gameFromDb =_gameService.Get(id);
            if(gameFromDb is not null)
            {
               _gameService.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        
    }
}
