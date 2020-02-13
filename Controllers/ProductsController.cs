using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using ODataService.Models;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                ID = 1,
                Name = "Bread",
            },
            new Product()
            {
                ID = 2,
                Name = "Eggs",
            }
        };

        [EnableQuery]
        public List<Product> Get()
        {
            return products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = products.Where(p => p.ID == key).AsQueryable();
            return SingleResult.Create(result);
        }
    }
}