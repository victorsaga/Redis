using System;
using Core;

namespace PubSub_Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入任意字符，輸入exit退出");
            string input;

            do
            {
                input = Console.ReadLine();
                new MyRedis().Subscriber.Publish("VicTestPubSub", input);
            } while (input != "exit");
        }
    }
}
