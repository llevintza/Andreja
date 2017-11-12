using System.Collections.Generic;
using DTO;

namespace Actions.Interfaces
{
    public interface IEmployeesAction
    {
        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Employee"/>.</returns>
        Employee GetEmployee(int id);

        /// <summary>
        /// The get all employeess.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Employee> GetAllEmployeess();

        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The <see cref="int"/>.</returns>
        int AddEmployee(Employee person);

        /// <summary>
        /// The update employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>The <see cref="Employee"/>.</returns>
        Employee UpdateEmployee(Employee employee);

        /// <summary>
        /// The delete employee.
        /// </summary>
        /// <param name="id"> The id.</param>
        void DeleteEmployee(int id);

        /// <summary>
        /// The delete employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void DeleteEmployee(Employee employee);
    }
}
