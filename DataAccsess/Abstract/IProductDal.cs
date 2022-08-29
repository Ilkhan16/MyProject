using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccsess.Abstract;

public interface IProductDal:IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();
}
