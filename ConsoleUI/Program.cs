using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var ppp in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine("**********************");
                Console.WriteLine(ppp.ProductName);
                Console.WriteLine(ppp.CategoryId);
            }
        }
    }
}
