using CommunityToolkit.Mvvm.ComponentModel;

namespace DotNetTraining.ViewModels
{
    partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? userName;

    }
}
