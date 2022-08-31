using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilites.Results.Abstract;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();   
        IDataResult<Category> GetById(int categoryId);
    }
}
