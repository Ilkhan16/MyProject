using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccsess.Abstract;

public interface IUserDal:IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}