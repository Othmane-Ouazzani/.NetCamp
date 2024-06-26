﻿using MaterialDesign;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaterialDesign
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged


    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();

        private bool _isMaterialDesign = false;
        public bool IsMaterialDesign
        {
            get { return _isMaterialDesign; }
            set
            {
                if (_isMaterialDesign != value)
                {
                    _isMaterialDesign = value;
                    OnPropertyChanged("IsMaterialDesign");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Window1()
        {
           
           




            ITheme theme = _paletteHelper.GetTheme();
            theme.SetPrimaryColor(System.Windows.Media.Color.FromRgb(200, 200, 0)); //red
            theme.SetSecondaryColor(System.Windows.Media.Color.FromRgb(0, 200, 0)); //green
            //theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark);
           
            _paletteHelper.SetTheme(theme);


            InitializeComponent();
            var resourcePairs = new Dictionary<string, string>
        {
            { "MaterialDesignFlatAccentBgButton", "CustomButtonStyle" },
            { "MaterialDesignToolButton", "myButton1" }
        };

            var converter = new GenericConverter(resourcePairs);
            Resources.Add("MyConverter", converter);
            this.DataContext = this;



        }
        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            PaletteHelper palette = new PaletteHelper();

            ITheme theme = palette.GetTheme();

            if (DarkModeToggle.IsChecked.Value)
            {
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Light);
            }
            palette.SetTheme(theme);
        }

        private void DarkModeToggle_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
