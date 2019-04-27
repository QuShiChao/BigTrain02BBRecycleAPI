using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using StackExchange.Redis;

namespace BBRecycle_Service.Controllers
{
    public class RedisHelper
    {
        //配置对象
        private static ConfigurationOptions configuration = ConfigurationOptions.Parse("10.1.152.4:6379");
        private static ConnectionMultiplexer connection;
        private static readonly object Locker = new object();
        public static IDatabase GetRedisDB()
        {
            if (connection == null)
            {
                lock (Locker)
                {
                    if (connection == null || connection.IsConnected)
                    {
                        connection = ConnectionMultiplexer.Connect(configuration);
                    }
                }
            }
            return connection.GetDatabase();
        }
        //写入
        public static void SetString(string key, string value, DateTime? date = null)
        {
            var db = GetRedisDB();
            db.StringSet(key, value);
            DateTime time = DateTime.Now.AddMinutes(10);
            db.KeyExpire(key, time);
        }
        //读取
        public static string GetString(string key)
        {
            var db = GetRedisDB();
            return db.StringGet(key);
        }
    }
}