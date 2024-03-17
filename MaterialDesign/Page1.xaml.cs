using DataGridExtensions;
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

namespace MaterialDesign
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// <summary>
    /// Logique d'interaction pour validation.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public List<Person> people { get; set; }

        public Page1()
        {
            InitializeComponent();
            BindingOperations.SetBinding(Column5, DataGridFilterColumn.DataGridFilterColumnControlProperty, new Binding("DataContext.Column5FilterColumnControl") { Source = this, Mode = BindingMode.TwoWay });

            people = new List<Person>
{
    new Person { Name = "John Doe", Age = 30, Email = "john.doe@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890", DateOfBirth = new DateTime(1991, 1, 1),IsElligebale=true },
    new Person { Name = "Jane Doe", Age = 28, Email = "jane.doe@example.com", Address = "456 Oak St", PhoneNumber = "987-654-3210", DateOfBirth = new DateTime(1993, 2, 2) ,IsElligebale=false},
    new Person { Name = "Bob Smith", Age = 35, Email = "bob.smith@example.com", Address = "789 Pine St", PhoneNumber = "456-789-0123", DateOfBirth = new DateTime(1986, 3, 3),IsElligebale=true },
    new Person { Name = "Alice Johnson", Age = 25, Email = "alice.johnson@example.com", Address = "987 Elm St", PhoneNumber = "789-012-3456", DateOfBirth = new DateTime(1996, 4, 4),IsElligebale=true },
    new Person { Name = "David Brown", Age = 40, Email = "david.brown@example.com", Address = "654 Birch St", PhoneNumber = "012-345-6789", DateOfBirth = new DateTime(1981, 5, 5) ,IsElligebale=false}
};

            this.DataContext = this;
        }
    }

}
