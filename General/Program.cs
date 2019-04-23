using System;
using Core;

namespace General
{
    class Program
    {
        static void Main(string[] args)
        {
            var newLine = System.Environment.NewLine;
            Console.WriteLine("請輸入指令，輸入exit退出"
                               + newLine + "StringSet VicTestKeyspace 999"
                               + newLine + "StringGet VicTestKeyspace"
                               + newLine + "KeyDelete VicTestKeyspace");
            string input;
            MyRedis redis = new MyRedis();
            string msg = "";

            while(true)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

                msg = "";
                if (!string.IsNullOrEmpty(input))
                {                 
                    string[] command = input.Split(' ');
                    switch(command[0].ToLower())
                    {
                        case "stringset": redis.StringSet(command[1], command[2]);
                            msg = "Done";
                            break;
                        case "stringget":
                            msg = redis.StringGet(command[1]);                            
                            break;
                        case "keydelete":
                            redis.KeyDelete(command[1]);
                            msg = "Done";
                            break;
                        default:
                            msg = "Incorrenct Command";
                            break;
                    }
                    Console.WriteLine(msg);
                }
            } 
        }
    }
}
