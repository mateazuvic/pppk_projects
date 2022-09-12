﻿using Microsoft.Win32;
using PersonManager.Utils;
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
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";

        private readonly Person person;
        public EditPersonPage(PersonViewModel personViewModel, TVShowViewModel tVShowViewModel, Person person = null) : base(personViewModel, tVShowViewModel)
        {
            InitializeComponent();
            this.person = person ?? new Person(); //elvis operator
            DataContext = person;
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                person.Age = int.Parse(TbAge.Text.Trim());
                person.Email = TbEmail.Text.Trim();
                person.FirstName = TbFirstName.Text.Trim();
                person.LastName = TbLastName.Text.Trim();
                person.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                if (person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(person);
                }
                else
                {
                    PersonViewModel.UpdatePerson(person);
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
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.IsValidEmail(TbEmail.Text.Trim())))
                {
                    e.Background = Brushes.Red;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.Red;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.White;
            }
            return valid;

        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

    }
}
