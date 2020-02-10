using System;
using DataFlow;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IDataFlow fl = new ConsoleFlow();
            fl.WriteData("test");
            fl = new CompressionDecorator(fl);
            fl.WriteData("test");
            fl = new EncryptionDecorator(fl);
            fl.WriteData("test");            
        }
    }
}
