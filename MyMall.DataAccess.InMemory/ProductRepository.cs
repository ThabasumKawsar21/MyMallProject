using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyMall.Core.Models;

namespace MyMall.DataAccess.InMemory
{
   public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;

            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void commit()
        {
            cache["products"]  = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product prodtoUpdated = (from result in products
                                     where result.ID == product.ID
                                     select result).FirstOrDefault();

            if (prodtoUpdated != null)
            {
                prodtoUpdated = product;
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }

        public Product Find(String ID)
        {
            Product product = (from result in products
                                     where result.ID == ID
                                     select result).FirstOrDefault();

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }
       public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }


        public void Delete(string Id)
        {
            Product prodtodelete = (from result in products
                                     where result.ID == Id
                                     select result).FirstOrDefault();

            if (prodtodelete != null)
            {
                products.Remove(prodtodelete);
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }
    }
}
