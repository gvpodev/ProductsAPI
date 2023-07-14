using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ProductsQuery), 201)]
    public IActionResult Create([FromBody] ProductsCreateCommand command)
    {
        return Ok();
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(ProductsQuery), 200)]
    public IActionResult Update([FromBody] ProductsUpdateCommand command)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProductsQuery), 200)]
    public IActionResult Remove([FromRoute] Guid? id)
    {
        return Ok();
    }
     
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductsQuery>), 200)]
    public IActionResult Find()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductsQuery), 200)]
    public IActionResult FindById([FromRoute] Guid? id)
    {
        return Ok();
    }
}