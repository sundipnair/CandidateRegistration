using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace CandidateRegistration.DataAccess.Sql
{
    public class CandidateRepo
    {
        private string _connectionString;
        private static readonly string MYSQL_CONNECTIONSTRING = "MYSQL_CONNECTIONSTRING";

        public CandidateRepo()
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            _connectionString = config[MYSQL_CONNECTIONSTRING];

            if (String.IsNullOrWhiteSpace(_connectionString))
            {
                _connectionString = "Server=127.0.0.1;Port=3306;Database=Candidate;Uid=sundip;Pwd=asdlkj;";
                //_connectionString = "host=127.0.0.1;port=3306;user id=sundip;password=asdlkj;database=Candidate;";
            }
        }

        internal Candidate GetCandidate(int id)
        {
            string sql = "select Id, FirstName, LastName, Email from BasicData where Id = @Id";

            Candidate candidate = null;

            using (var conn = new MySqlConnection(_connectionString))
            {
                //conn.Open();
                candidate = conn.Query<Candidate>(sql, new { Id = id }).SingleOrDefault(); ;
            }

            return candidate;
        }
    }
}
