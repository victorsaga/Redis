using System;
using Core;

namespace Keyspace_Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            string subKey = "VicTestKeyspace";

            /* 通过config set指令来在线keyspace配置.

                开启所有的事件
                redis-cli config set notify-keyspace-events KEA

                开启keyspace Events
                redis-cli config set notify-keyspace-events KA

                开启keyspace 所有List 操作的 Events
                redis-cli config set notify-keyspace-events Kl
             */


            string value = "";

            var redis = new MyRedis();
            redis.Subscriber.Subscribe($"__keyspace@0__:{subKey}", (channel, eventType) =>            
            {
                value = eventType == "set" ? redis.StringGet(subKey) : "";
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {channel} {eventType} {value}");                
            });
            Console.WriteLine($"已訂閱Keyspace:{subKey}");
            Console.ReadKey();
        }
    }
}
