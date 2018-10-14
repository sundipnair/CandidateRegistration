using StackExchange.Redis;
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

        public void SetListValue(string key, string value)
        {
            _database.StringSet(key, value);
        }

        public void DeleteListValue(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
