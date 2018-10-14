using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateRegistration.Service;
using Microsoft.AspNetCore.Mvc;

namespace CandidateRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        // GET api/candidates
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            return new CandidateService().GetCandidates();
        }

        // GET api/candidates/5
        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            return new CandidateService().GetCandidate(id);
        }

        // POST api/candidates
        [HttpPost]
        public void Post([FromBody] Candidate candidate)
        {
            new CandidateService().CreateCandidate(candidate);
        }

        // PUT api/candidates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Candidate candidate)
        {
            new CandidateService().UpdateCandidate(id, candidate);
        }

        // DELETE api/candidates/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new CandidateService().DeleteCandidate(id);
        }
    }
}
