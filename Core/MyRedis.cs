using System;
using StackExchange.Redis;

namespace Core
{
    public class MyRedis
    {        
        private ConnectionMultiplexer _redis;
        public ISubscriber Subscriber => new Lazy<ISubscriber>(() => _redis.GetSubscriber()).Value;
        public IDatabase _db => new Lazy<IDatabase>(() => _redis.GetDatabase()).Value;
        public MyRedis()
        {
            _redis = ConnectionMultiplexer.Connect(new ConfigurationOptions()
                        {
                            EndPoints =
                                {
                                    "dev-redis:6379"
                                },
                            ConnectTimeout = 5000,
                            SyncTimeout = Int32.MaxValue,
                            AllowAdmin = false,
                            Ssl = false,
                            AbortOnConnectFail = false,
                        });
        }

        public void StringSet(string key, string value)
        {
            _db.StringSet(key, value);
        }
        public string StringGet(string key)
        {
            return _db.StringGet(key);
        }
        public void KeyDelete(string key)
        {
            _db.KeyDelete(key);
        }


    }
}
