using System;
using Core;

namespace PubSub_Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {   
            new MyRedis().Subscriber.Subscribe("VicTestPubSub", (channel, message) =>
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            });
            Console.WriteLine("已訂閱 messages");
            Console.ReadKey();        

        }
    }
}
