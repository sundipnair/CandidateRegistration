﻿using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateRegistration.DataAccess.Redis
{
    public class RedisConnectionFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        private static readonly string REDIS_CONNECTIONSTRING = "REDIS_CONNECTIONSTRING";

        static RedisConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            string connectionString = config[REDIS_CONNECTIONSTRING];

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new KeyNotFoundException($"Environment variable for {REDIS_CONNECTIONSTRING} was not found.");
            }

            var options = ConfigurationOptions.Parse(connectionString);

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }

        public static ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
