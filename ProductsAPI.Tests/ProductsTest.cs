using System.Net;
using Bogus;
using FluentAssertions;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Tests.Helpers;

namespace ProductsAPI.Tests;

public class ProductsTest
{
    private readonly string? _endpoint;
    private readonly Faker? _faker;

    public ProductsTest()
    {
        _endpoint = "/api/products";
        _faker = new Faker("pt_BR");
    }
    
    [Fact]
    public async Task<ProductsDTO?> Test_Products_Post_Returns_Created()
    {
        var command = new ProductsCreateCommand
        {
            Name = _faker?.Commerce.ProductName(),
            Price = decimal.Parse(_faker?.Commerce.Price(2)),
            Quantity = _faker.Random.Number(1, 100)
        };
        var client = TestHelper.CreateClient;

        var result = await client.PostAsync(_endpoint, TestHelper.CreateContent(command));

        result.StatusCode.Should().Be(HttpStatusCode.Created);
        return TestHelper.ReadResponse<ProductsDTO>(result);
    }

    [Fact]
    public async Task<ProductsDTO?> Test_Products_Put_Returns_Ok()
    {
        var createdProductDto = await Test_Products_Post_Returns_Created();
        var command = new ProductsUpdateCommand()
        {
            Id = createdProductDto?.Id,
            Name = _faker?.Commerce.ProductName(),
            Price = decimal.Parse(_faker?.Commerce.Price(2)),
            Quantity = _faker.Random.Number(1, 100)
        };
        var client = TestHelper.CreateClient;

        var result = await client.PutAsync(_endpoint, TestHelper.CreateContent(command));

        var content = TestHelper.ReadResponse<ProductsDTO>(result);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content?.Id.Should().Be(command.Id);
        content?.Name.Should().Be(command.Name);
        content?.Price.Should().Be(command.Price);
        content?.Quantity.Should().Be(command.Quantity);
        return content;
    }

    [Fact]
    public async Task Test_Products_Delete_Returns_Ok()
    {
        var createdProductDto = await Test_Products_Post_Returns_Created();
        var client = TestHelper.CreateClient;

        var result = await client.DeleteAsync($"{_endpoint}/{createdProductDto?.Id}");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Test_Products_GetAll_Returns_Ok()
    {
        var createdProductDto = await Test_Products_Post_Returns_Created();
        var client = TestHelper.CreateClient;

        var result = await client.GetAsync(_endpoint);

        var list = TestHelper.ReadResponse<List<ProductsDTO>>(result);
        list?.FirstOrDefault(p => p.Id.Equals(createdProductDto?.Id)).Should().NotBeNull();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Test_Products_GetById_Returns_Ok()
    {
        var createdProductDto = await Test_Products_Post_Returns_Created();
        var client = TestHelper.CreateClient;

        var result = await client.GetAsync($"{_endpoint}/{createdProductDto?.Id}");

        var content = TestHelper.ReadResponse<ProductsDTO>(result);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        content?.Id.Should().Be(createdProductDto?.Id);
        content?.Name.Should().Be(createdProductDto?.Name);
        content?.Price.Should().Be(createdProductDto?.Price);
        content?.Quantity.Should().Be(createdProductDto?.Quantity);
    }
}

