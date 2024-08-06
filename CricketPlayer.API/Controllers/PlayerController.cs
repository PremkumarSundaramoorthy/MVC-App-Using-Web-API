using CricketPlayer.API.Data;
using CricketPlayer.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CricketPlayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Player> players = _dbContext.Player.ToList();

            return Ok(players);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int Id)
        {
            Player player = _dbContext.Player.Where(x => x.Id == Id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpGet]
        [Route("GetOrderedListByRank")]
        public IActionResult GetOrderedListByRank()
        {
            List<Player> players = _dbContext.Player.OrderBy(x => x.Rank).ToList();

            return Ok(players);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Player player)
        {
            _dbContext.Player.Add(player);

            _dbContext.SaveChanges();

            return NoContent();
        }


        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Player _player)
        {
            Player player = _dbContext.Player.AsNoTracking().Where(x => x.Id == _player.Id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }

            _dbContext.Player.Update(_player);

            _dbContext.SaveChanges();

            return NoContent();
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            Player player = _dbContext.Player.Where(x => x.Id == Id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }

            _dbContext.Player.Remove(player);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
