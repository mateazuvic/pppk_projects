using Azure.Storage.Blobs.Models;
using FilesManager.ViewModels;
using Microsoft.Win32;
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

namespace FilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ItemsViewModel itemsViewModel;
        public MainWindow()
        {
            InitializeComponent();
            itemsViewModel = new ItemsViewModel();
            Init();
        }

        private void Init()
        {
            LbBlobs.ItemsSource = itemsViewModel.Items;
            CbDirectories.ItemsSource = itemsViewModel.Directories;
        }

        private void LbBlobs_SelectionChanged(object sender, SelectionChangedEventArgs e) => DataContext = LbBlobs.SelectedItem as BlobItem;


        private async void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Svg Image (.svg)|*.svg";
            if (openFileDialog.ShowDialog() == true)
            {
                await itemsViewModel.UploadAsync(openFileDialog.FileName);
            }
            CbDirectories.Text = itemsViewModel.Directory;
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbBlobs.SelectedItem is BlobItem blobItem))
            {
                return;
            }
            await itemsViewModel.DeleteAsync(blobItem);
            CbDirectories.Text = itemsViewModel.Directory;
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbBlobs.SelectedItem is BlobItem blobItem))
            {
                return;
            }
            var saveFileDialog = new SaveFileDialog()
            {
                FileName = blobItem.Name.Contains(ItemsViewModel.ForwardSlash)
                ? blobItem.Name.Substring(blobItem.Name.LastIndexOf(ItemsViewModel.ForwardSlash) + 1)
                : blobItem.Name
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                await itemsViewModel.DownloadAsync(blobItem, saveFileDialog.FileName);
            }
            CbDirectories.Text = itemsViewModel.Directory;
        }

        private void CbDirectories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                itemsViewModel.Directory = CbDirectories.Text;
            }
        }

        private void CbDirectories_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itemsViewModel.Directories.Contains(CbDirectories.Text))
            {
                itemsViewModel.Directory = CbDirectories.Text;
                CbDirectories.SelectedItem = itemsViewModel.Directory;

            }
        }
    }
}

