using System;
using System.Collections.Generic;

using DataAccess.Interfaces;

using Models;

namespace DataAccess {
    public class PersonRepository : IPersonRepository {
        private readonly List<string> FirstNames = new List<string> {
            "Kevin", "Jennifer", "Vince", "Julie"
        };

        private readonly List<string> LastNames = new List<string> {
            "Skoglund", "Aniston", "Vaughn", "Bowen"
        };

        private readonly Random random;

        public PersonRepository() {
            random = new Random();
        }

        public IEnumerable<Person> LoadPersons() {
            var personsCount = random.Next(3, 5);
            for (int i = 0; i < personsCount; i++) {
                yield return new Person { FirstName = GenerateRandomFirstName(), LastName = GenerateRandomLastName(), };
            }
        }

        private string GenerateRandomFirstName() {
            return this.ChooseNameFrom(FirstNames);
        }

        private string GenerateRandomLastName() {
            return this.ChooseNameFrom(LastNames);
        }

        private string ChooseNameFrom(IList<string> collection) {
            return collection[random.Next(0, collection.Count)];
        }
    }
}
