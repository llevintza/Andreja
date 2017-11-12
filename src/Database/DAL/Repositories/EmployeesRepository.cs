using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using AutoMapper;

using DAL.Repositories.Interface;

using DTO;

using Logging;

namespace DAL.Repositories
{
    /// <summary>
    /// The employees repository.
    /// </summary>
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {

        private readonly IMapper mapper;

        private Logger log;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesRepository"/> class.
        /// </summary>
        /// <param name="dbSet">
        /// The database set.
        /// </param>
        public EmployeesRepository(
            DbSet<Employee> dbSet,
            IMapper mapper)
            : base(dbSet)
        {
            this.mapper = mapper;
            this.log = new Logger(this.GetType());
        }

        /// <inheritdoc />
        public DTO.Employee GetEmployee(int id)
        {
            return this.mapper.Map<DTO.Employee>(this.AsQueryable().FirstOrDefault(x => x.Id == id));
        }


        /// <inheritdoc />
        public IEnumerable<DTO.Employee> GetAllEmployeess()
        {
            return this.GetAll().Select(this.mapper.Map<DTO.Employee>).ToList();
        }


        /// <inheritdoc />
        public int AddEmployee(DTO.Employee employee)
        {
            var entity = this.mapper.Map<Employee>(employee);

            return this.Add(entity).Id;
        }

        /// <inheritdoc />
        public DTO.Employee UpdateEmployee(DTO.Employee employee)
        {
            try
            {
                var entity = this.mapper.Map<Employee>(employee);
                this.Update(entity);

                return employee;
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to update the {nameof(employee)} record", ex);
            }

            return null;
        }

        /// <inheritdoc />
        public void DeleteEmployee(int id)
        {
            try
            {
                var entity = this.AsQueryable().FirstOrDefault(x => x.Id == id);
                this.Delete(entity);
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to delete the  {typeof(Employee)} record with Id = {id}", ex);
            }
        }


        /// <inheritdoc />
        public void DeleteEmployee(DTO.Employee employee)
        {
            try
            {
                var entity = this.mapper.Map<Employee>(employee);
                this.Delete(entity);
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to delete the  {typeof(Employee)} record with Id = {employee.Id}", ex);
            }
        }
    }
}
