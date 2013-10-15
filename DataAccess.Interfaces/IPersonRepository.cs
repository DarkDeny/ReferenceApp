using System.Collections.Generic;

using Models;

namespace DataAccess.Interfaces {
    public interface IPersonRepository {
        IEnumerable<Person> LoadPersons();
    }
}
