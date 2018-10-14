using CandidateRegistration.DataAccess.Sql;
using Microsoft.AspNetCore.Mvc;
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
        }

        internal void CreateCandidate(Candidate candidate)
        {
            new CandidateRepo().CreateCandidate(candidate);
        }

        internal ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            return new CandidateRepo().GetCandidates();
        }

        internal void UpdateCandidate(int id, Candidate candidate)
        {
            new CandidateRepo().UpdateCandidate(id, candidate);
        }

        internal void DeleteCandidate(int id)
        {
            new CandidateRepo().DeleteCandidate(id);
        }
    }
}
