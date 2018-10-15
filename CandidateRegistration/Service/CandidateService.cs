using CandidateRegistration.DataAccess.Redis;
using CandidateRegistration.DataAccess.Sql;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateRegistration.Service
{
    public class CandidateService
    {
        internal Candidate GetCandidate(int id)
        {
            return new CandidateRepo().GetCandidate(id);

            // get from Redis
            //string data = new RedisDataAgent().GetStringValue($"candidate_{id}");

            //if (!String.IsNullOrWhiteSpace(data))
            //    return JsonConvert.DeserializeObject<Candidate>(data);
            //else
            //    return null;
        }

        internal void CreateCandidate(Candidate candidate)
        {
            // create on sql and redis
            int id = new CandidateRepo().CreateCandidate(candidate);

            new RedisDataAgent().SetStringValue($"candidate_{id}", JsonConvert.SerializeObject(candidate));
        }

        internal ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            // get from redis
            return new CandidateRepo().GetCandidates();
        }

        internal void UpdateCandidate(int id, Candidate candidate)
        {
            // update on sql and redis
            new CandidateRepo().UpdateCandidate(id, candidate);

            //new RedisDataAgent().SetStringValue($"candidate_{id}", JsonConvert.SerializeObject(candidate));
        }

        internal void DeleteCandidate(int id)
        {
            // delete from sql and redis
            new CandidateRepo().DeleteCandidate(id);

            //new RedisDataAgent().DeleteKey($"candidate_{id}");
        }
    }
}
