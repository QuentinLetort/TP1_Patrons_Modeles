using System;

namespace DataFlow
{
    public class ConsoleFlow : IDataFlow
    {   
        public void WriteData(string data){
            Console.WriteLine(data);
        }
        public string ReadData(){
            return Console.ReadLine();
        }
    }
}