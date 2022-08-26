using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                    { ProductId = 1, CategoryId = 1, ProductName = "Kinetix Sergy 2FX", UnitPrice = 449, UnitsInStock = 100 },
                new Product
                    { ProductId = 2, CategoryId = 3, ProductName = "MONOGRAM OMZ 2FX KAHVE MULTI Kadın Kol Çantası", UnitPrice = 199, UnitsInStock = 5 },
                new Product
                    { ProductId = 3, CategoryId = 1, ProductName = "EFTAL 2FX Yeşil Kadın Sandalet", UnitPrice = 329, UnitsInStock = 1 },
                new Product
                    { ProductId = 4, CategoryId = 2, ProductName = "SN79 BASIC C NECK SWEATSH Ekru Kadın Sweatshirt", UnitPrice = 199, UnitsInStock = 7 },
                new Product
                    { ProductId = 5, CategoryId = 1, ProductName = "SIAS 2FX Kadın Topuklu Sandalet", UnitPrice = 159 , UnitsInStock = 68 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productTUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productTUpdate.ProductId = product.ProductId;
            productTUpdate.ProductName = product.ProductName;
            productTUpdate.CategoryId = product.CategoryId;
            productTUpdate.UnitPrice = product.UnitPrice;
            productTUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}

