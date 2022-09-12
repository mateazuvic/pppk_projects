using PPPK2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK2
{
    public class FramedPage : Page
    {
        //pametan page
        public PersonViewModel PersonViewModel { get; }
        public TVShowViewModel TVShowViewModel { get; }
        public Frame Frame { get; set; }

        public FramedPage(PersonViewModel personViewModel, TVShowViewModel tvShowViewModel)
        {
            PersonViewModel = personViewModel;
            TVShowViewModel = tvShowViewModel;
        }
    }
}

