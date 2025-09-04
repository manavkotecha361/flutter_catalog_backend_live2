using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCatalogApi.webapi.Data;
using MyCatalogApi.webapi.Models;

namespace MyCatalogApi.webapi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    // Explicit HEAD action
    // GET automatically supports HEAD unless overridden
    [HttpGet("ping")]
    public IActionResult GetPing()
    {
        return StatusCode(200);
    }
}