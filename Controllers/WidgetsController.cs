// using Microsoft.AspNetCore.Mvc;
// using MyCatalogApi.webapi.Data;
// using MyCatalogApi.webapi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace MyCatalogApi.webapi.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class WidgetsController : ControllerBase
// {
//     private readonly AppDbContext _context;

//     public WidgetsController(AppDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Widget>>> GetWidgets()
//     {
//         return await _context.Widgets.Include(w => w.Category).ToListAsync();
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<Widget>> GetWidget(string id)
//     {
//         var widget = await _context.Widgets.Include(w => w.Category).FirstOrDefaultAsync(w => w.Id == id);
//         if (widget == null) return NotFound();
//         return widget;
//     }

//     [HttpGet("category/{categoryId}")]
//     public async Task<ActionResult<IEnumerable<Widget>>> GetWidgetsByCategory(string categoryId)
//     {
//         var widgets = await _context.Widgets
//             .Where(w => w.CategoryId == categoryId)
//             .Include(w => w.Category)
//             .ToListAsync();
//         if (widgets == null || !widgets.Any()) return NotFound();
//         return widgets;
//     }

//     [HttpGet("favorite")]
//     public async Task<ActionResult<IEnumerable<Widget>>> GetFavoriteWidgets()
//     {
//         var widgets = await _context.Widgets
//             .Where(w => w.IsFavorite)
//             .Include(w => w.Category)
//             .ToListAsync();
//         return widgets;
//     }

//     [HttpPut("toggleFavorite/{id}")]
//     public async Task<IActionResult> ToggleFavorite(string id, [FromBody] bool isFavorite)
//     {
//         var widget = await _context.Widgets.FindAsync(id);
//         if (widget == null) return NotFound();
//         widget.IsFavorite = isFavorite;
//         await _context.SaveChangesAsync();
//         return NoContent();
//     }


//     private bool WidgetExists(string id)
//     {
//         return _context.Widgets.Any(e => e.Id == id);
//     }
// }

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCatalogApi.webapi.Data;
using MyCatalogApi.webapi.Models;

namespace MyCatalogApi.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WidgetsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WidgetsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Widget>>> GetWidgets()
    {
        return await _context.Widgets.Include(w => w.Category).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Widget>> GetWidget(string id)
    {
        var widget = await _context.Widgets
            .Include(w => w.Category)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (widget == null) return NotFound();
        return widget;
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Widget>>> GetWidgetsByCategory(string categoryId)
    {
        var widgets = await _context.Widgets
            .Where(w => w.CategoryId == categoryId)
            .Include(w => w.Category)
            .ToListAsync();

        if (!widgets.Any()) return NotFound();
        return widgets;
    }

    [HttpGet("favorite")]
    public async Task<ActionResult<IEnumerable<Widget>>> GetFavoriteWidgets()
    {
        return await _context.Widgets
            .Where(w => w.IsFavorite)
            .Include(w => w.Category)
            .ToListAsync();
    }

    [HttpPut("toggleFavorite/{id}")]
    public async Task<IActionResult> ToggleFavorite(string id, [FromBody] bool isFavorite)
    {
        var widget = await _context.Widgets.FindAsync(id);
        if (widget == null) return NotFound();

        widget.IsFavorite = isFavorite;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
