using System.Collections.Generic;
using Actions.Interfaces;

using DAL.Repositories.Interface;

using DTO;

namespace Actions
{
    public class PersonsAction : IPersonsAction
    {
        /// <summary>
        /// The persons repository.
        /// </summary>
        private readonly IPersonsRepository personsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsAction"/> class.
        /// </summary>
        /// <param name="personsRepository">
        /// The persons repository.
        /// </param>
        public PersonsAction(IPersonsRepository personsRepository)
        {
            this.personsRepository = personsRepository;
        }

        /// <inheritdoc />
        public Person GetPerson(int id)
        {
            return this.personsRepository.GetPerson(id);
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAllPersons()
        {
            return this.personsRepository.GetAllPersons();
        }

        /// <inheritdoc />
        public int AddPerson(Person person)
        {
            return this.personsRepository.AddPerson(person);
        }

        /// <inheritdoc />
        public Person UpdatePerson(Person person)
        {
            return this.personsRepository.UpdatePerson(person);
        }

        /// <inheritdoc />
        public void DeletePerson(int id)
        {
            this.personsRepository.DeletePerson(id);
        }

        /// <inheritdoc />
        public void DeletePerson(Person person)
        {
            this.personsRepository.DeletePerson(person);
        }
    }
}
