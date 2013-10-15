using DataAccess;
using DataAccess.Interfaces;

using StructureMap;

namespace Population {
    class ContainerBootstrapper {
        public static void BootstrapStructureMap() {
            ObjectFactory.Initialize(
                x => x.For<IPersonRepository>().Use<PersonRepository>());
        }
    }
}
