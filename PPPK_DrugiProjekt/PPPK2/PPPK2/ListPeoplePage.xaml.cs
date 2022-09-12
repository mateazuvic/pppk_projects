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
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(PersonViewModel personViewModel, TVShowViewModel tVShowViewModel) : base(personViewModel, tVShowViewModel)
        {
            InitializeComponent();
            LvUsers.ItemsSource = personViewModel.People;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvUsers.SelectedItem != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, TVShowViewModel, LvUsers.SelectedItem as Person) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvUsers.SelectedItem != null /*&& !IsPersonAssignedToCourse()*/)
            {
                PersonViewModel.People.Remove(LvUsers.SelectedItem as Person);
            }
            else
            {
                MessageBox.Show("For some reason it is impossible to delete person!");
            }

        }

        //private bool IsPersonAssignedToCourse()
        //{
        //    return CourseViewModel.Courses.Where(c => c.Professor.Equals(LvUsers.SelectedItem as Person)).Any();
        //}

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPersonPage(PersonViewModel, TVShowViewModel) { Frame = Frame });

    }
}

