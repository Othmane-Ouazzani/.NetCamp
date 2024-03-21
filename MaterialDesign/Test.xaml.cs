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
using System.Windows.Shapes;

namespace MaterialDesign
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window


    {
        Dictionary<Button, string> buttonStyles = new Dictionary<Button, string>();

        public Test()
        {
            InitializeComponent();
            buttonStyles.Add(Button1, "CustomButtonStyle");
            buttonStyles.Add(Button2, "myButton1");
        }



        public void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            UnloadResourceDictionary("Dictionary1.xaml");
            LoadResourceDictionary("MaterialDesignDictionary.xaml");
            UpdateButtonStyles();
        }

        public void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            UnloadResourceDictionary("MaterialDesignDictionary.xaml");
            LoadResourceDictionary("Dictionary1.xaml");
            UpdateButtonStyles();
        }

        private void LoadResourceDictionary(string source)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(source, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        private void UnloadResourceDictionary(string source)
        {
            var dict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.OriginalString == source);
            if (dict != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(dict);
            }
        }
        private void UpdateButtonStyles()
        {


            foreach (var buttonStyle in buttonStyles)
            {
                Style style = Application.Current.Resources[buttonStyle.Value] as Style;
                if (style != null)
                {
                    buttonStyle.Key.Style = style;
                }
            }
        }
    }
}