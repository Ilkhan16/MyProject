using Business.Abstract;
using Business.Constans;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager:IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour==15)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        };
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
    {
        return new SuccessDataResult<List<Product>>( _productDal.GetAll(product => product.CategoryId == categoryId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>( _productDal.GetAll(product => product.UnitPrice >= min && product.UnitPrice <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour==16)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
    }

    public IResult Add(Product product) 
    {
        if (product.ProductName.Length < 2)
        {
            return new ErrorResult(Messages.ProductNameInvalid);
        }

        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }
}