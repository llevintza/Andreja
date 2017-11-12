using System.Collections.Generic;
using System.Web.Http;

using DTO;

using Actions.Interfaces;

using Web.Portal.App_Start;

namespace Web.Portal.Controllers
{
    using System.Linq;

    [Route("api/employee")]
    public class EmployeesController : ApiController
    {

        private readonly IEmployeesAction action;

        public EmployeesController(IEmployeesAction action)
        {
            this.action = action;
        }

        public EmployeesController()
        {
            this.action = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IEmployeesAction>();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Employee> Get()
        {
            return this.action.GetAllEmployeess().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Employee Get(int id)
        {
            return this.action.GetEmployee(id);
        }

        [HttpPost]
        public void Post([FromBody]Employee value)
        {
            this.action.AddEmployee(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody]Employee value)
        {
            value.Id = id;

            this.action.UpdateEmployee(value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.action.DeleteEmployee(id);
        }
    }
}
