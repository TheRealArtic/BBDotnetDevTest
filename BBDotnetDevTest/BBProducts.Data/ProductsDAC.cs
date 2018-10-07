using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BBProducts.Api.Models;

namespace BBProducts.Data
{
    public class ProductsDAC
    {
        private BBProductsDBEntities _entityModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsDAC() => _entityModel = new BBProductsDBEntities();

        public ProductsResponseDTO GetProducts()
        {
            var productDTOArr = _entityModel.Products.Select(x => new ProductDTO() { ID = x.Id }).ToArray();
            var productResponseDTO = new ProductsResponseDTO() { Id = Guid.NewGuid().ToString(), Timestamp = DateTime.Now, Products = productDTOArr };

            return productResponseDTO;
        }

        public ProductsResponseDTO GetProducts(long id)
        {
            var productDTOArr = _entityModel.Products.Where(x => x.Id == id).Select(x => new ProductDTO() { ID = x.Id, Name = x.Name, Quantity = x.Quantity, SaleAmount = x.Sale_Amount }).ToArray();
            var productResponseDTO = new ProductsResponseDTO() { Id = Guid.NewGuid().ToString(), Timestamp = DateTime.Now, Products = productDTOArr };

            return productResponseDTO;
        }
    }
}
