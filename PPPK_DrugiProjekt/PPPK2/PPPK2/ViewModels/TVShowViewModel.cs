using PersonManager.Dal;
using PPPK2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK2.ViewModels
{
    public class TVShowViewModel
    {
        public ObservableCollection<TVShow> TVShows { get; }

        public TVShowViewModel()
        {
            TVShows = new ObservableCollection<TVShow>(RepositoryFactory.GetRepository().GetTVShows());
            TVShows.CollectionChanged += TVShows_CollectionChanged;
        }

        private void TVShows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddTVShow(TVShows[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteTVShow(e.OldItems.OfType<TVShow>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateTVShow(e.NewItems.OfType<TVShow>().ToList()[0]);
                    break;
            }
        }

        public void UpdateTVShow(TVShow tvShow) => TVShows[TVShows.IndexOf(tvShow)] = tvShow;
    }

}
