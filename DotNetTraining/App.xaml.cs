using BCrypt.Net;
using DotNetTraining.Data;
using DotNetTraining.Models;
using System;
using System.Configuration;
using BCrypt.Net;
using System.Data;
using System.Windows;
using DotNetTraining.Repositories;

namespace DotNetTraining
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override  async void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);



            IUserRepository userRepository = new UserRepository(new UserDbContext());


            IEnumerable<User> users = new List<User>
            {
                new User(new Guid(),"Ouazzani", "Touhami", BCrypt.Net.BCrypt.HashPassword("123456"), "4Y5eK@example.com"),
                new User(new Guid(),"John", "Doe", BCrypt.Net.BCrypt.HashPassword("password123"), "john.doe@example.com"),
                new User(new Guid(),"new Guid()Jane", "Smith", BCrypt.Net.BCrypt.HashPassword("letmein"), "jane.smith@example.com"),
                new User(new Guid(),"Michael", "Johnson", BCrypt.Net.BCrypt.HashPassword("securepassword"), "michael.johnson@example.com"),

            };
                

            foreach (User user in users)
            {
                 await userRepository.SaveUserAsync(user);

            }




        }
    }
}