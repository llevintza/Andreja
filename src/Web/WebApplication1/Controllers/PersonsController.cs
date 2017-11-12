using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Portal.Controllers
{
    using Actions.Interfaces;

    using DTO;

    [Route("api/persons")]
    public class PersonsController : ApiController
    {

        private readonly IPersonsAction action;

        public PersonsController(IPersonsAction action)
        {
            this.action = action;
        }
        
        [HttpGet]
        [Route("all")]
        public IEnumerable<Person> Get()
        {
            return this.action.GetAllPersons();
        }

        [HttpGet]
        [Route("{id}")]
        public Person Get(int id)
        {
            return this.action.GetPerson(id);
        }
        
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            this.action.AddPerson(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody]Person value)
        {
            value.Id = id;

            this.action.UpdatePerson(value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.action.DeletePerson(id);
        }
    }
}
