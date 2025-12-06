using Microsoft.AspNetCore.Mvc;
using NGG.NewGames.Api.DataAccess;

namespace NGG.NewGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewGamesController(NGG_NewGamesDbContext dbContext) : ControllerBase
{
    [HttpGet]
   public  IActionResult Get()
   {
        var all = dbContext.NewGames.ToList();
        return Ok(all);
   }
}
