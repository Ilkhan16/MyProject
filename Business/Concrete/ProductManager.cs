using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Castle.Components.DictionaryAdapter;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilites.Business;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    ICategoryService _categoryService;
    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour >= 22 && DateTime.Now.Hour <= 1)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        };
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(product => product.CategoryId == categoryId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(product => product.UnitPrice >= min && product.UnitPrice <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour == 14)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductsListed);
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
             CheckIfProductCountOfCategoryCorrect(product.CategoryId));
        if (result != null)
        {
            return result;
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }






                                   //--------------Rules-------------------\\
    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var products = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
        if (products >= 10)
        {
            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }

        return new SuccessResult();
    }
    private IResult CheckIfProductNameExists(string productname)
    {
        var products = _productDal.GetAll(p => p.ProductName == productname).Any();
        if (products)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }

        return new SuccessResult();
    }
}