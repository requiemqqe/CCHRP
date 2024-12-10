using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { ID = 1, Name = "Computer", Description = "Gaming computer", Price = 45000.50f, Stock = 3 },
        new Product { ID = 2, Name = "Mac", Description = "Working mac", Price = 30000.50f, Stock = 5 }
    };

    // GET /api/products
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        try
        {
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET /api/products/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<Product> GetProductById(int id)
    {
        try
        {
            var product = products.FirstOrDefault(x => x.ID == id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST /api/products
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<Product> CreateProduct(Product product)
    {
        try
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest(new { message = "Product data is invalid." });
            }

            product.ID = products.Any() ? products.Max(x => x.ID) + 1 : 1;
            products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ID }, product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT /api/products/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult UpdateProduct(int id, Product product)
    {
        try
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest(new { message = "Product data is invalid." });
            }

            var existingProduct = products.FirstOrDefault(x => x.ID == id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE /api/products/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            var product = products.FirstOrDefault(x => x.ID == id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            products.Remove(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
