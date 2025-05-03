using Microsoft.AspNetCore.Mvc;
using API.DTO;
using API.Model;
using API.Service;
using System.Collections.Generic;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly MongoDBService _mongoDbService;

        public ScoresController(MongoDBService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }
        
        [HttpPost]
        public ActionResult SubmitScore([FromBody] ScoreDto dto)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(dto.Username))
                return BadRequest("El nombre del usuario es obligatorio");
            if (dto.TimeSeconds < 0)
                return BadRequest("El cronómetro es negativo");

            var score = new Score
            {
                Username = dto.Username,
                TimeSeconds = dto.TimeSeconds
            };

            _mongoDbService.AddScore(score);
            return Ok("Score añadido");
        }

        // Método para el top 10
        [HttpGet("top10")]
        public ActionResult<List<Score>> GetTop10()
        {
            var topScores = _mongoDbService.GetTopScores(10);
            return Ok(topScores);
        }
    }
}