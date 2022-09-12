using PPPK2.Models;
using PPPK2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPPK2
{
    /// <summary>
    /// Interaction logic for ListTVShowsPage.xaml
    /// </summary>
    public partial class ListTVShowsPage : FramedPage
    {
        public ListTVShowsPage(PersonViewModel personViewModel, TVShowViewModel tVShowViewModel) : base(personViewModel, tVShowViewModel)
        {
            InitializeComponent();
            LvTVShows.ItemsSource = tVShowViewModel.TVShows;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvTVShows.SelectedItem != null)
            {
                Frame.Navigate(new EditTVShowPage(PersonViewModel, TVShowViewModel, LvTVShows.SelectedItem as TVShow) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvTVShows.SelectedItem != null /*&& !IsPersonAssignedToCourse()*/)
            {
                TVShowViewModel.TVShows.Remove(LvTVShows.SelectedItem as TVShow);
            }
            else
            {
                MessageBox.Show("For some reason it is impossible to delete show!");
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditTVShowPage(PersonViewModel, TVShowViewModel) { Frame = Frame });

    }
}
