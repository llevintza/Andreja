using System.Collections.Generic;

namespace DAL.Repositories.Interface
{
    public interface IPersonsRepository
    {
        DTO.Person GetPerson(int id);

        IEnumerable<DTO.Person> GetAllPersons();

        int AddPerson(DTO.Person person);

        DTO.Person UpdatePerson(DTO.Person person);

        void DeletePerson(int ind);

        void DeletePerson(DTO.Person person);
    }
}
