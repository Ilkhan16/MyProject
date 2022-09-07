using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;

namespace ConsoleUI;

class Program
{
    static void Main()
    {

        //NewMethod();
        //NewMethod1();
    }
    









 

    private static void NewMethod1()
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Console.WriteLine(categoryManager.GetById(5));
        Console.WriteLine("**************************");
        foreach (var cccc in categoryManager.GetAll().Data)
        {
            Console.WriteLine("{0} {1}", cccc.CategoryId, "****** " + cccc.CategoryName);
        }   

        Console.ReadLine();
    }


    //private static void NewMethod()
    //{
    //    ProductManager productManager = new ProductManager(new EfProductDal());

    //    var result = productManager.GetProductDetails();

    //    if (result.Success)
    //    {
    //        foreach (var ppp in productManager.GetProductDetails().Data)
    //        {
    //            Console.WriteLine(ppp.ProductName + " *** " + ppp.CategoryName);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine(result.Message);
    //    }
    //}
}