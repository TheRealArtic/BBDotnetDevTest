using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BBProducts.Api.Models;
using BBProducts.Data;

namespace BBProducts.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsDAC _prodDac = new ProductsDAC();

        [HttpGet]
        public IHttpActionResult GetProduct()
        {
            return Ok(_prodDac.GetProducts());
        }

        [HttpGet]
        public IHttpActionResult GetProduct(long id)
        {
            var response = _prodDac.GetProducts(id);
            if (response.Products.Count() == 0) return NotFound();

            return Ok(_prodDac.GetProducts(id));
        }

        [HttpPost]
        public IHttpActionResult AddProduct(ProductDTO[] input)
        {
            if (input == null || input.Length == 0) return BadRequest("No data provided");

            _prodDac.AddProducts(input);

            return Ok("Added");
        }
    }
}
