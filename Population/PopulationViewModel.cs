using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using DataAccess.Interfaces;

using Models;

using MVVM;

namespace Population {
    public class PopulationViewModel : ViewModelBase{
        public PopulationViewModel(IPersonRepository repository) {
            _Repository = repository;
            _People = new List<Person>();
        }

        public ICommand LoadPopulationCommand {
            get {
                return new DelegateCommand(canExecute => true, LoadPopulation);
            }
        }

        public string PopulationTotalText {
            get {
                return String.Format("We have {0} person(s) in current population.", _People.Count());
            }
        }

        public IEnumerable<Person> Population {
            get {
                return _People;
            }
            private set {
                _People = value;
                OnPropertyChanged();
                OnPropertyChanged("PopulationTotalText");
            }
        }

        private readonly IPersonRepository _Repository;

        private IEnumerable<Person> _People;

        private void LoadPopulation() {
            var newPopulation = new List<Person>();
            newPopulation.AddRange(_Repository.LoadPersons());
            Population = newPopulation;
        }
    }
}
