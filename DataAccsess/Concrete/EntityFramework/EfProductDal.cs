using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccsess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var result = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName,
                    UnitsInStock = p.UnitsInStock
                };
            return result.ToList();
        }
    }
}