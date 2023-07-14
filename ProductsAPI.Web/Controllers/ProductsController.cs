using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Remove()
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Find()
    {
        return Ok();
    }
}