using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
using System.Collections.Generic;
using System.Linq;


[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => products;

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(product => product.Id == id);
        return product != null ? Ok(product) : NotFound();
    }
    [HttpPost]
    public ActionResult<Product> Create(Product newProduct)
    {
        newProduct.Id = products.Count + 1;
        products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { Id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(item => item.Id == id);
        if (product == null) return NotFound();
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> Delete(int id)
    {
        var product = products.FirstOrDefault(item => item.Id == id);
        if (product == null) return NotFound();
        products.Remove(product);
        return NoContent();

    }
}