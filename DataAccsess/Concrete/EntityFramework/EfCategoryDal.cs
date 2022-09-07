using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
{
}