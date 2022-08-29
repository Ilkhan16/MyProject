using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;

namespace ConsoleUI;

class Program
{
    static void Main()
    {
        NewMethod();
        //NewMethod1();
    }
    











    private static void NewMethod1()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Console.WriteLine(categoryManager.GetByCategoryId(5));
        Console.WriteLine("**************************");
        foreach (var cccc in categoryManager.GetAll())
        {
            Console.WriteLine("{0} {1}", cccc.CategoryId, "****** " + cccc.CategoryName);
        }

        Console.ReadLine();
    }


    private static void NewMethod()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var ppp in productManager.GetProductDetails())
        {
            Console.WriteLine(ppp.ProductName+" *** "+ppp.CategoryName);
        }
    }
}