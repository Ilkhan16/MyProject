using Core.DataAccess;
using Entities.Concrete;

namespace DataAccsess.Abstract;

public interface ICustomerDal : IEntityRepository<Customer>
{

}