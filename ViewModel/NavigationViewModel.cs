using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Repositories;
using HostelControlService.Utils;
using HostelControlService.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HostelControlService.ViewModel
{
    internal class NavigationViewModel:ViewModelBase
    {
        #region Fields
        private bool _isAdmin;
        private bool _isVisible;
        private UserAccountModel _currentUser;
        private object _currentView;
        private IUserRepository userRepository;

        public bool IsAdmin 
        { 
            get => _isAdmin;
            set 
            { 
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            } 
        }
        public bool IsVisible 
        { 
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            } 
        }
        public UserAccountModel CurrentUser 
        { 
            get => _currentUser;
            set 
            { 
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            } 
        }
        public object CurrentView 
        { 
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            } 
        }
        #endregion

        #region Commands
        public ICommand AdminCommand { get; }
        public ICommand HostelRoomCommand { get; }
        public ICommand OrderCommand { get; }

        #endregion


        #region Constructor
        public NavigationViewModel() 
        {
            userRepository = new UserRepository();

            LoadCurrentUser();

            AdminCommand = new ViewModelCommand(Admin, CanExecuteAdminCommand);
            HostelRoomCommand = new ViewModelCommand(Hostel);
            OrderCommand = new ViewModelCommand(Order);
        }

        #endregion

        #region Methods
        private void Admin(object obj) => CurrentView = new AdminView();
        private void Hostel(object obj) => CurrentView = new HostelRoomView();
        private void Order(object obj) => CurrentView = new OrderView();

        private void LoadCurrentUser() 
        {
            var user = userRepository.GetByName(Thread.CurrentPrincipal.Identity.Name);

            if (user != null) 
            {
                CurrentUser = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"{user.Name}",
                    AccessLevel = user.AccessLevel
                };
            }
            else
            {
              // MessageBox.Show("Ошибка! Пользователь неавторизирован", "Ошибка авторизации", 
              // MessageBoxButton.OK, MessageBoxImage.Error);

               // Application.Current.Shutdown();

            }
        }

        private bool CanExecuteAdminCommand(object obj)
        {
            bool isAdmin;
            if (CurrentUser.AccessLevel == 0)
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }

            IsVisible = isAdmin;
            return isAdmin;
        }
        #endregion


    }
}
