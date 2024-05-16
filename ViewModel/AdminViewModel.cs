using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Repositories;
using HostelControlService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostelControlService.ViewModel
{
    internal class AdminViewModel : ViewModelBase
    {
        #region Field
        private UserRepository userRepository = new UserRepository();
        private AccessRepository accessRepository = new AccessRepository();

        private IEnumerable<UserModel> userModels;
        private IEnumerable<AccessModel> accessModels;
        private UserModel _currentUser;
        #endregion


        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public IEnumerable<UserModel> UserModels
        {
            get { return userModels; }
            set
            {
                userModels = value;
                OnPropertyChanged(nameof(UserModels));
            }
        }

        internal IEnumerable<AccessModel> AccessModels 
        { 
            get => accessModels;
            set
            {
                accessModels = value;
                OnPropertyChanged(nameof(AccessModels));
            }
        }

        #region Commands
        public ICommand AdminAddCommand { get;}
        public ICommand AdminEditCommand { get; }
        public ICommand AdminDeleteCommand { get; }
        #endregion

        #region Edit
        private bool CanExecuteEditCommand(object obj)
        {
            if (CurrentUser != null && CurrentUser.Username != "admin")
            {
                return true;
            }
            return false;
        }

        private void ExecuteEditCommand(object obj)
        {
            userRepository.Edit(CurrentUser);
            UserModels = userRepository.GetAll();
        }
        private bool CanExecutedDeletedCommand(object obj)
        {
            if (CurrentUser != null && CurrentUser.Username != "admin")
            {
                return true;
            }
            return false;
        }

        private void ExecuteDeleteCommand(object obj)
        {
            userRepository.Remove(CurrentUser.Id);
            UserModels = userRepository.GetAll();
        }

        private void ExecuteAddCommand(object obj)
        {
            userRepository.Add(CurrentUser);
            UserModels = userRepository.GetAll();
        }
        #endregion

        #region Constructor
        public AdminViewModel()
        {
            userRepository = new UserRepository();
            accessRepository = new AccessRepository();


            UserModels = userRepository.GetAll();
            accessModels = accessRepository.GetAll();

            AdminEditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
            AdminDeleteCommand = new ViewModelCommand(ExecuteDeleteCommand, CanExecutedDeletedCommand);
            AdminAddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        }

        private bool CanExecuteAddCommand(object obj)
        {
            return true;
        }
        #endregion
    }
}
