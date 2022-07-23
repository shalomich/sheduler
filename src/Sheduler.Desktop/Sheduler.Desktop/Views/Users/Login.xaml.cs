﻿using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Mvvm.ViewModels.Users;

namespace Sheduler.Desktop.Views.Users
{
    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>
    [UsesViewModel(typeof(LoginViewModel))]
    public partial class Login : NavigationPage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            var dataContext = (LoginViewModel)DataContext;

            // The `Password Box` control does not have bindable `password` property.
            dataContext.Model.Password = PasswordBox.Password;
        }
    }
}
