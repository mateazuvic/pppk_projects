using PPPK2.Models;
using System.Collections.Generic;

namespace PersonManager.Dal
{
    public interface IRepository
    {
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Person GetPerson(int idPerson);
        IList<Person> GetPeople();

        void AddTVShow(TVShow tvShow);
        void UpdateTVShow(TVShow tvShow);
        void DeleteTVShow(TVShow tvShow);
        TVShow GetTVShow(int idShow);
        IList<TVShow> GetTVShows();
    }
}
