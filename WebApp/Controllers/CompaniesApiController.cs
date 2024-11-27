using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Movies;

namespace WebApp.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesApiController : ControllerBase
{
    private readonly MoviesDbContext _dbContext;

    public CompaniesApiController(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetFiltered(string fragment)
    {
        return Ok(
            _dbContext.ProductionCompanies
                .Where(c => c.CompanyName.ToLower().Contains(fragment.ToLower()))
                .AsNoTracking()
                .AsEnumerable()
        );
    }
}