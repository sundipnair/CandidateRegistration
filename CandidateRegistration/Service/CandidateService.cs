using CandidateRegistration.DataAccess.Sql;
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
    }
}
