using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Candidate candidate = new Candidate
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Builder",
                Email = "bob@builder.com"
            };
            return new Candidate[] { candidate };
        }

        // GET api/candidates/5
        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            return new Candidate
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Builder",
                Email = "bob@builder.com"
            };
        }

        // POST api/candidates
        [HttpPost]
        public void Post([FromBody] Candidate candidate)
        {
        }

        // PUT api/candidates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Candidate candidate)
        {
        }

        // DELETE api/candidates/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
