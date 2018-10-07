using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            return Ok(_prodDac.GetProducts(id));
        }
    }
}
