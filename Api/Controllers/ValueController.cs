using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Controllers
{
    [Route("api/{Controller}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()

        {
            var Values=  await _dataContext.Values.ToListAsync();
            return Ok(Values);
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value=await _dataContext.Values.FindAsync(id);
            return Ok(value) ;
        }

        // POST: api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/values/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
