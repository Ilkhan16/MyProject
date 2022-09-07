using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CCS.Abstract;

namespace Business.CCS.Concrete;

public class FileLogger:ILogger
{
    public void Log()
    {
        Console.WriteLine("Files Logged");
    }
}