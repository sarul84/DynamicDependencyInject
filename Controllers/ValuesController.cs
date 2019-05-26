using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicDependencyInject.Providers;
using DynamicDependencyInject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicDependencyInject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServicesProvider<IProvider> servicesProvider;

        public ValuesController(IServicesProvider<IProvider> servicesProvider)
        {
            this.servicesProvider = servicesProvider;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{provider}")]
        public ActionResult<string> Get(string provider)
        {
            return this.servicesProvider.GetInstance(provider).GetName();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
