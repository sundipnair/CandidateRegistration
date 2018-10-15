using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace CandidateRegistration.DataAccess.Redis
{
    public class RedisDataAgent
    {
        private static IDatabase _database;

        public RedisDataAgent()
        {
            var connection = RedisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
        }

        public string GetStringValue(string key)
        {
            return _database.StringGet(key);
        }

        public void SetStringValue(string key, string value)
        {
            bool res = _database.StringSet(key, value, null, When.Always, CommandFlags.None);

            if (!res)
                throw new Exception("Not Cached");
            else
                throw new Exception("Cached Updated");
        }

        public void UpdateStringValue(string key, string value)
        {
            _database.StringSet(key, value);
        }

        public void DeleteKey(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
