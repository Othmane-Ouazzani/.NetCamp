using CommunityToolkit.Mvvm.Input;
using DotNetTraining.Models;
using DotNetTraining.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;

namespace DotNetTraining.ViewModels
{
    class RegisterViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _password;
        private bool _isRegisterEnabled;
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public ICommand RegisterCommand { get; set; }
        private readonly IUserRepository userRepository;
        

        public RegisterViewModel(IUserRepository userRepository)
        {
            RegisterCommand = new RelayCommand(RegisterUser);
            this.userRepository = userRepository;
        }

        public bool IsRegisterEnabled
        {
            get { return _isRegisterEnabled; }
            set
            {
                _isRegisterEnabled = value;
                OnPropertyChanged(nameof(IsRegisterEnabled));
            }
        }

        private void UpdateRegisterButtonState()
        {
            IsRegisterEnabled = !HasErrors && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        public bool HasErrors => _errorsByPropertyName.Any();

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                ValidateFirstName();
                UpdateRegisterButtonState();
            }
        }

        public string LastName
        {
            get { return _lastName; }

            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                ValidateLastName();
                UpdateRegisterButtonState();
            }

        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                ValidateEmail();
                UpdateRegisterButtonState();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                ValidatePassword();
                UpdateRegisterButtonState();
            }
        }

        private void RegisterUser()
        {
            if(IsUserExists()) {
                MessageBox.Show("The user already exists.", "User Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            User newUser = new User(new Guid(),FirstName, LastName,BCrypt.Net.BCrypt.HashPassword(Password),Email);
            userRepository.SaveUserAsync(newUser);
         


        }

        //private bool CanRegisterUser()
        //{
        //    return /*!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) &&*/ HasErrors;
        //}



        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        public IEnumerable? GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }



        //////////////////////////////////////////Validations

        private void ValidateFirstName()
        {
            ClearErrors(nameof(FirstName));
            if (string.IsNullOrWhiteSpace(FirstName))
                AddError(nameof(FirstName), "First name is required.");
            else if (!Regex.IsMatch(FirstName, "^[a-zA-Z]+$"))
                AddError(nameof(FirstName), "First name must contain only letters.");
        }

        private void ValidateLastName()
        {
            ClearErrors(nameof(LastName));
            if (string.IsNullOrWhiteSpace(LastName))
                AddError(nameof(LastName), "Last name is required.");
            else if (!Regex.IsMatch(LastName, "^[a-zA-Z]+$"))
                AddError(nameof(LastName), "Last name must contain only letters.");
        }

        private void ValidateEmail()
        {
            ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
                AddError(nameof(Email), "Email is required.");
            else if (!Regex.IsMatch(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                AddError(nameof(Email), "Invalid email format.");
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrWhiteSpace(Password))
            {
                AddError(nameof(Password), "Password is required.");
            }
            else
            {
                if (!Regex.IsMatch(Password, @"^(?=.*[A-Z])(?=.*[0-9]).{10,}$"))
                    AddError(nameof(Password), "Password must be at least 10 characters long, contain at least one uppercase letter, and at least one digit.");
            }
        }

        private bool IsUserExists()
        {
            return userRepository.GetUserByEmailAsync(Email) != null;
        }












    }
}

