using System.Collections;
using Core.Entities;

namespace Entities.Concrete;

public class Category:IEntity, IEnumerable
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}