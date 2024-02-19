namespace DotNetTraining.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _phoneNumber;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropretyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }

            set
            {
                _lastName = value;
                OnPropretyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropretyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropretyChanged(nameof(Password));
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropretyChanged(nameof(PhoneNumber));
            }
        }

        private void RegisterUser()
        {

        }

    }
}
