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
        /// <summary>
        /// ProductDAC for retrieving backend data
        /// </summary>
        private ProductsDAC _prodDac = new ProductsDAC();

        /// <summary>
        /// Retrieves a list of all product ids
        /// </summary>
        /// <returns>List of product ids, with timestamp and unique event id</returns>
        [HttpGet]
        public IHttpActionResult GetProduct()
        {
            ProductsResponseDTO response = new ProductsResponseDTO();
            response.Id = Guid.NewGuid().ToString();
            response.Timestamp = new DateTime().ToUniversalTime();
            response.Products = _prodDac.GetProducts();

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific product based on product id
        /// </summary>
        /// <param name="id">Product ID of product to retrieve</param>
        /// <returns>404 if product does not exist, full product information with timestamp and unique event id if otherwise</returns>
        [HttpGet]
        public IHttpActionResult GetProduct(long id)
        {
            var products = _prodDac.GetProducts(id);
            if (products.Length == 0) return NotFound();

            ProductsResponseDTO response = new ProductsResponseDTO();
            response.Id = Guid.NewGuid().ToString();
            response.Timestamp = new DateTime().ToUniversalTime();
            response.Products = _prodDac.GetProducts();

            return Ok(response);
        }

        /// <summary>
        /// Adds a list of products to the database
        /// </summary>
        /// <param name="input">An array of Products</param>
        /// <returns>201 Created if the creation was successful, BadRequest with error messages if otherwise</returns>
        [HttpPost]
        public IHttpActionResult AddProduct(ProductDTO[] input)
        {
            if (input == null || input.Length == 0) return BadRequest("No data provided");

            _prodDac.AddProducts(input);

            return Ok("Added");
        }
    }
}
