using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
{
}