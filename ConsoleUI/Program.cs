using System;
using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;

namespace ConsoleUI
{
    class program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var ppp in productManager.GetAll())
            {
                Console.WriteLine("**********************");
                Console.WriteLine(ppp.ProductName);

            }

            Console.ReadLine();
        }
    }
}

