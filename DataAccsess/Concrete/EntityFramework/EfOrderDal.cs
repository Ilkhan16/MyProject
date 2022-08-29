using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfOrderDal:EfEntityRepositoryBase<Order,NorthwindContext>,IOrderDal
{
}