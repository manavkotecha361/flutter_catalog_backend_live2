// using Microsoft.AspNetCore.Mvc;
// using MyCatalogApi.webapi.Data;
// using MyCatalogApi.webapi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace MyCatalogApi.webapi.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class CategoriesController : ControllerBase
// {
//     private readonly AppDbContext _context;

//     public CategoriesController(AppDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
//     {
//         return await _context.Categories.ToListAsync();
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<Category>> GetCategory(string id)
//     {
//         var category = await _context.Categories.FindAsync(id);
//         if (category == null) return NotFound();
//         return category;
//     }

//     private bool CategoryExists(string id)
//     {
//         return _context.Categories.Any(e => e.Id == id);
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCatalogApi.webapi.Data;
using MyCatalogApi.webapi.Models;

namespace MyCatalogApi.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(string id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return category;
    }
}
