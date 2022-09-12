using PersonManager.Dal;
using PPPK2.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PPPK2.ViewModels
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> People { get; } //readonly

        public PersonViewModel()
        {
            People = new ObservableCollection<Person>(RepositoryFactory.GetRepository().GetPeople());

            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddPerson(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePerson(e.OldItems.OfType<Person>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePerson(e.NewItems.OfType<Person>().ToList()[0]);
                    break;
            }
        }

        public void UpdatePerson(Person person) => People[People.IndexOf(person)] = person;
    }
}

