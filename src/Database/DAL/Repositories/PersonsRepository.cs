using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using AutoMapper;

using DAL.DbEntities;
using DAL.Repositories.Interface;

namespace DAL.Repositories
{
    using Logging;

    public class PersonsRepository : GenericRepository<Person>, IPersonsRepository
    {
        private readonly IMapper mapper;

        private Logger log;

        public PersonsRepository(
            DbSet<Person> dbSet,
            IMapper mapper)
            : base(dbSet)
        {
            this.mapper = mapper;
            this.log = new Logger(this.GetType());
        }

        public DTO.Person GetPerson(int id)
        {
            return this.mapper.Map<DTO.Person>(this.AsQueryable().FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<DTO.Person> GetAllPersons()
        {
            return this.GetAll().Select(this.mapper.Map<DTO.Person>).ToList();
        }

        public int AddPerson(DTO.Person person)
        {
            var entity = this.mapper.Map<Person>(person);

            return this.Add(entity).Id;
        }

        public DTO.Person UpdatePerson(DTO.Person person)
        {
            try
            {
                var entity = this.mapper.Map<Person>(person);
                this.Update(entity);

                return person;
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to update the {nameof(person)} record", ex);
            }

            return null;
        }

        public void DeletePerson(int id)
        {
            try
            {
                var entity = this.AsQueryable().FirstOrDefault(x => x.Id == id);
                this.Delete(entity);
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to delete the  {typeof(Person)} record with Id = {id}", ex);
            }
        }

        public void DeletePerson(DTO.Person person)
        {
            try
            {
                var entity = this.mapper.Map<Person>(person);
                this.Delete(entity);
            }
            catch (Exception ex)
            {
                this.log.Error($"Failed to delete the  {typeof(Person)} record with Id = {person.Id}", ex);
            }
        }
    }
}
