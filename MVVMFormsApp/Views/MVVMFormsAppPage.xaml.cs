﻿using MVVMFormsApp;
using Xamarin.Forms;

namespace MVVMFormsApp
{
    public partial class MVVMFormsAppPage : ContentPage
    {
        public MVVMFormsAppPage()
        {
            InitializeComponent();

             BindingContext = new MainViewModel();
        }
    }
}
