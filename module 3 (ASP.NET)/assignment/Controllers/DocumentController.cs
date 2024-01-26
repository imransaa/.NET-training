using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        // GET: api/<DocumentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public string GetDocument(int id)
        {
            return "value";
        }

        // POST api/<DocumentController>
        [HttpPost]
        public void CreateDocument([FromBody] string value)
        {
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/<ValuesController>/auth/10
        [HttpPost("auth/{id}")]
        public void AddAuth(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/auth/10
        [HttpDelete("auth/{id}")]
        public void RemoveAuth(int id, [FromBody] string value)
        {
        }
    }
}
