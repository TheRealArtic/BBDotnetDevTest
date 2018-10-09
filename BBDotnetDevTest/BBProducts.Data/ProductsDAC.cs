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
        /// <summary>
        /// EDM Used to connect with LocalDB
        /// </summary>
        private BBProductsDBEntities _entityModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsDAC() => _entityModel = new BBProductsDBEntities();

        /// <summary>
        /// Intermediary method to get all ProductIds. Converts EDM objects to POCO DTOs
        /// </summary>
        /// <returns>List of Product IDs in a ProductDTO wrapper</returns>
        public ProductDTO[] GetProducts()
        {
            var productDTOArr = _entityModel.Products.Select(x => new ProductDTO() { ID = x.Id }).ToArray();
            return productDTOArr;
        }

        /// <summary>
        /// Intermediary method to get a specific product. Converts EDM objects to POCO DTOs
        /// </summary>
        /// <param name="id">ID of the product to retrieve</param>
        /// <returns>Full information of the product specified by the ID</returns>
        public ProductDTO[] GetProducts(long id)
        {
            var productDTOArr = _entityModel.Products.Where(x => x.Id == id).Select(x => new ProductDTO() { ID = x.Id, Name = x.Name, Quantity = x.Quantity, SaleAmount = x.Sale_Amount }).ToArray();
            return productDTOArr;
        }

        public void AddProducts(params ProductDTO[] newInputs)
        {
            foreach(var input in newInputs)
            {
                Product p = new Product()
                {
                        Id = input.ID,
                        Name = input.Name,
                        Quantity = input.Quantity.GetValueOrDefault(0),
                        Sale_Amount = input.SaleAmount.GetValueOrDefault(0),
                        Id_Updated_By = "User",
                        Dt_Updated_By = DateTime.Now
                };

                _entityModel.Products.Add(p);
            }

            _entityModel.SaveChanges();
        }
    }
}
