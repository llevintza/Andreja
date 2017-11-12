using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using DAL.DbEntities;

using Logging;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly Logger log;

        public ApplicationDbContext()
            : base("name=ApplicationDbConnectionString")
        {
            this.log = new Logger(this.GetType());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // do nothing
        }

        #region tables

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Person> Persons { get; set; }

        #endregion

        public List<T> ExecuteSelectProcedure<T>(string procedureName, params SqlParameter[] parameters)
        {
            this.log.Debug($"Executing {procedureName}");

            foreach (var parameter in parameters)
            {
                this.log.Debug($"Name {parameter.ParameterName}, Value {parameter.Value}");
            }

            var procedureExecName = GetExecProcedureName(procedureName, parameters);

            var result = null as List<T>;//this.Database.SqlQuery<T>(procedureExecName, parameters);

            var resultList = result.ToList();

            this.log.Debug($"Execution result of {procedureName}:");

            return resultList;
        }

        public T ExecuteSelectScalarProcedure<T>(string procedureName, params SqlParameter[] parameters)
        {
            this.log.Debug($"Executing {procedureName}");

            foreach (var parameter in parameters)
            {
                this.log.Debug($"Name {parameter.ParameterName}, Value {parameter.Value}");
            }

            var procedureExecName = GetExecProcedureName(procedureName, parameters);

            var result = null as List<T>;//this.Database.SqlQuery<T>(procedureExecName, parameters);

            var resultObject = result.FirstOrDefault();

            this.log.Debug($"Execution result of {procedureName}:");

            return resultObject;
        }

        public void ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
        {
            this.log.Debug($"Executing {procedureName}");

            foreach (var parameter in parameters)
            {
                this.log.Debug($"Name {parameter.ParameterName}, Value {parameter.Value}");
            }

            var procedureExecName = GetExecProcedureName(procedureName, parameters);

            //this.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, procedureExecName, parameters);

            this.log.Debug("Executed {procedureName}");
        }


        private static string GetExecProcedureName(string procedureName, SqlParameter[] parameters)
        {
            var procedureExecName = string.Format("{0} {1}", procedureName, string.Join(",",
                parameters.Select(x => string.Format("@{0}{1}", x.ParameterName,
                    x.Direction == System.Data.ParameterDirection.Output ? " out" : string.Empty))
                .ToList()));
            return procedureExecName;
        }

        private static string GetExecCommandProcedureName(string procedureName, SqlParameter[] parameters)
        {
            var procedureExecName = GetExecProcedureName(procedureName, parameters);

            return $"Exec {procedureExecName}";
        }
    }
}
