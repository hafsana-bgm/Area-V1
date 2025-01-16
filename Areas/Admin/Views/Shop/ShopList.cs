using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Area_v1.Areas.Admin.Views.Shop
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopList : ControllerBase
    {
        // GET: api/<ShopList>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShopList>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShopList>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShopList>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShopList>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
