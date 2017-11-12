using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.Interfaces
{
    public interface IPersonsAction
    {

        DTO.Person GetPerson(int id);

        IEnumerable<DTO.Person> GetAllPersons();

        int AddPerson(DTO.Person person);

        DTO.Person UpdatePerson(DTO.Person person);

        void DeletePerson(int ind);

        void DeletePerson(DTO.Person person);
    }
}
