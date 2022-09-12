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
    /// Interaction logic for EditTVShowPage.xaml
    /// </summary>
    public partial class EditTVShowPage : FramedPage
    {
        private readonly TVShow tvShow;
        public EditTVShowPage(PersonViewModel personViewModel, TVShowViewModel tVShowViewModel, TVShow tvShow = null) : base(personViewModel, tVShowViewModel)
        {
            InitializeComponent();
            this.tvShow = tvShow ?? new TVShow();
            DataContext = tvShow;
            CbTVHost.ItemsSource = personViewModel.People;
            

        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                tvShow.Name = TbName.Text.Trim();
                tvShow.Rating = int.Parse(TbRating.Text.Trim());
                tvShow.TVHost = CbTVHost.SelectedItem as Person;
                if (tvShow.IDShow == 0)
                {
                    TVShowViewModel.TVShows.Add(tvShow);
                }
                else
                {
                    TVShowViewModel.UpdateTVShow(tvShow);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
                {
                    e.Background = Brushes.Red;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            GridContainer.Children.OfType<ComboBox>().ToList().ForEach(c =>
            {
                if (c.SelectedIndex == -1)
                {
                    string message = "Please choose TV host!";
                    string title = "Warning";
                    MessageBox.Show(message, title);
                    valid = false;
                }
                else
                {
                    c.Background = Brushes.White;
                }
            });
            return valid;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

    }
}
