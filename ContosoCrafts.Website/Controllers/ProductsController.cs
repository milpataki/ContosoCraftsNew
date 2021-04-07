using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.Extensions.Primitives;

namespace ContosoCrafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // https://localhost:44321/products/Rate?ProductId=jenlooper-light&Rating=4
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId, 
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId,Rating);
            return Ok();
        }
    }
}
