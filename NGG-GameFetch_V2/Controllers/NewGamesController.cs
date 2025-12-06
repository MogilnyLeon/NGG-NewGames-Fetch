using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGG_GameFetch_V2.NewGames.Api.DataAccess;

namespace NGG_GameFetch_V2.NewGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewGamesController(NGG_NewGamesDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var all = await dbContext.NewGames.ToListAsync();
        return Ok(all);
    }

    [HttpGet("id", Name = nameof(GetbyId))]
    public async Task<IActionResult> GetbyId(int id)
    {
        var newGame = await dbContext.NewGames.Include(g => g.Genre)
            .Where(g =>  g.Id == id)
            .FirstOrDefaultAsync();

        return Ok(newGame);
    }

    [HttpPost]
    public async Task<IActionResult> Create( addedNewGame addedNewGame)
    {
        var newGame = addedNewGame.ToNewGame();
        await dbContext.AddAsync(newGame);
        await dbContext.SaveChangesAsync();
        return CreatedAtRoute(nameof(GetbyId), new {id = newGame.Id}, addedNewGame);
    }
}

public record addedNewGame(string Name, string Description, int Year, int Month, int Day, int GenreId)
{
    public NewGame ToNewGame()
    {
        return new NewGame
        {
            Name = Name,
            Description = Description,
            ReleaseDate = new DateTime(Year, Month, Day),
            GenreId = GenreId
        };
    }
}
