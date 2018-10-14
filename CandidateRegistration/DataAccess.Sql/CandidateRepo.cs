using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;

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
            }
        }

        internal void DeleteCandidate(int id)
        {
            string sql = "delete from BasicData where Id = @Id";

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Execute(sql, new { Id = id });
            }
        }

        internal void UpdateCandidate(int id, Candidate candidate)
        {
            string sql = "update BasicData set Email = @Email where Id = @Id";

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Execute(sql, new { Id = id, Email = candidate.Email });
            }
        }

        internal ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            string sql = "select Id, FirstName, LastName, Email from BasicData";

            List<Candidate> candidates = new List<Candidate>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                candidates = conn.Query<Candidate>(sql).ToList();
            }

            return candidates;
        }

        internal void CreateCandidate(Candidate candidate)
        {
            string sql = "insert into BasicData (FirstName, LastNAme, Email) values (@FirstName, @LastNAme, @Email)";

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Execute(sql, new { FirstName = candidate.FirstName, LastName = candidate.LastName, Email = candidate.Email });
            }
        }

        internal Candidate GetCandidate(int id)
        {
            string sql = "select Id, FirstName, LastName, Email from BasicData where Id = @Id";

            Candidate candidate = null;

            using (var conn = new MySqlConnection(_connectionString))
            {
                candidate = conn.Query<Candidate>(sql, new { Id = id }).SingleOrDefault();
            }

            return candidate;
        }
    }
}
