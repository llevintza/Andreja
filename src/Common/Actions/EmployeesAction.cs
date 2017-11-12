using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using Actions.Interfaces;
using DAL.Repositories.Interface;
namespace Actions
{
    using DTO;

    public class EmployeesAction: IEmployeesAction
    {

        private readonly IEmployeesRepository repository;

        public EmployeesAction(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        public Employee GetEmployee(int id)
        {
            return this.repository.GetEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployeess()
        {
            return this.repository.GetAllEmployeess().ToList();
        }

        public int AddEmployee(Employee employee)
        {
            return this.repository.AddEmployee(employee);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return this.repository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            this.repository.DeleteEmployee(id);
        }

        public void DeleteEmployee(Employee employee)
        {
            this.repository.DeleteEmployee(employee);
        }
    }
}
