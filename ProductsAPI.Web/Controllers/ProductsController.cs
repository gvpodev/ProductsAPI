using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.Contracts;
using ProductsAPI.Application.Contracts.Services;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductAppService? _productAppService;

    public ProductsController(IProductAppService? productAppService)
    {
        _productAppService = productAppService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductsDTO), 201)]
    public async Task<IActionResult> Create([FromBody] ProductsCreateCommand command)
    {
        var response = await _productAppService?.Create(command);

        return StatusCode(201, response);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(ProductsDTO), 200)]
    public async Task<IActionResult> Update([FromBody] ProductsUpdateCommand command)
    {
        var response = await _productAppService?.Update(command);

        return StatusCode(200, response);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProductsDTO), 200)]
    public async Task<IActionResult> Remove([FromRoute] Guid? id)
    {
        var command = new ProductsDeleteCommand { Id = id };
        var response = await _productAppService?.Delete(command);

        return StatusCode(200, response);
    }
     
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductsDTO>), 200)]
    public IActionResult Find() => StatusCode(200, _productAppService?.FindAll());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductsDTO), 200)]
    public IActionResult FindById([FromRoute] Guid id) => StatusCode(200, _productAppService?.FindById(id));
}