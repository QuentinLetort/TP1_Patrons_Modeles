using System;
using DataFlow;
using JobSystem;
using API;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiBuilder builder = new ApiBuilder();
            builder.SetConsoleProtocol();
            builder.SetCompression();
            builder.SetNbThread(10);

            Api api = builder.GetResult();
            api.CreateConnection();
            for (int i = 0; i < 20; i++)
            {
                api.Send("data" + i);
            }
            System.Threading.Thread.Sleep(5000);
            api.CloseConnection();

            
        }
    }
}
