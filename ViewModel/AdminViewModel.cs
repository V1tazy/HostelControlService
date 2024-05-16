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
        private string _username;
        private string _password;
        private string _name;
        private string _lastName;
        private int _accessId;

        private string _roleName;

        private AccessModel _currentRole;
        private UserModel _currentUser;

        private IEnumerable<AccessModel> listRoles;
        private IEnumerable<UserModel> listUsers;

        private IUserRepository userRepository;
        private IAccessRepository accessRepository;

        public AccessModel CurrentRole
        {
            get => _currentRole;
            set
            {
                _currentRole = value;
                OnPropertyChanged(nameof(CurrentRole));
            }
        }
        
        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public string RoleName
        {
            get => _roleName;
            set
            {
                RoleName = value;
                OnPropertyChanged(nameof(RoleName));
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public int AccessId
        {
            get => _accessId;
            set
            {
                _accessId = value;
                OnPropertyChanged(nameof(AccessId));
            }
        }

        internal IEnumerable<AccessModel> ListRoles
        {
            get => listRoles;
            set
            {
                listRoles = value;
                OnPropertyChanged(nameof(ListRoles));
            }
        }
        internal IEnumerable<UserModel> ListUsers
        {
            get => listUsers;
            set
            {
                listUsers = value;
                OnPropertyChanged(nameof(ListUsers));
            }
        }
        #endregion

        #region Command
        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand RefreshUserCommand { get; }
        public ICommand ClearUserCommand { get; }

        public ICommand AddRoleCommand { get; }
        public ICommand EditRoleCommand { get; }
        public ICommand DeleteRoleCommand { get; }

        #endregion

        #region Constructor
        public AdminViewModel()
        {
            userRepository = new UserRepository();
            accessRepository = new AccessRepository();

            ListUsers = userRepository.GetAll();
            ListRoles = accessRepository.GetAll();

            AddUserCommand = new ViewModelCommand(ExecuteUserAddCommand, CanExecuteUserAddCommand);
            EditUserCommand = new ViewModelCommand(ExecuteUserEditCommand, CanExecuteUserGroupCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteUserDeleteCommand, CanExecuteUserGroupCommand);
            RefreshUserCommand = new ViewModelCommand(ExecuteUserRefreshCommand, CanExecuteUserGroupCommand);
            ClearUserCommand = new ViewModelCommand(ExecuteUserClearCommand, CanExecuteUserGroupCommand);

            AddRoleCommand = new ViewModelCommand(ExecuteAddRoleCommand, CanExecuteRoleAddCommand);
            EditRoleCommand = new ViewModelCommand(ExecuteEditRoleCommand, CanExecuteRoleGroupCommand);

        }
        #endregion

        #region Methods
        private void ExecuteUserAddCommand(object obj)
        {
            bool isUserExist = userRepository.GetByName(Username) == null;

            if (isUserExist)
            {
                userRepository.Add(new UserModel()
                {
                    Username = Username,
                    Password = Password,
                    Name = Name,
                    LastName = LastName,
                    AccessLevel = AccessId
                });
            }
        }

        private void ExecuteUserEditCommand(object obj)
        {
            userRepository.Edit(CurrentUser);
            ListUsers = userRepository.GetAll();
        }

        private void ExecuteUserDeleteCommand(object obj)
        {
            userRepository.Remove(CurrentUser.Id);
        }

        private void ExecuteUserRefreshCommand(object obj)
        {
            ListUsers = userRepository.GetAll();
            ListRoles = accessRepository.GetAll();
        }

        private void ExecuteUserClearCommand(object obj)
        {
            Username = null;
            Password = null;
            Name = null;
            LastName = null;
            AccessId = 0;
        }

        private void ExecuteAddRoleCommand(object obj) 
        {
            
        }

        private void ExecuteEditRoleCommand(object obj)
        {

        }

        private void ExecuteDeleteRoleCommand(object obj)
        {

        }

        private void ExecuteRefreshRoleCommand(object obj)
        {

        }

        private void ExecuteClearRoleCommand(object obj)
        {

        }

        private bool CanExecuteUserAddCommand(object obj)
        {
            if(Username.Length < 5 || Password.Length < 5) 
                return false;

            return true;
        }

        private bool CanExecuteUserGroupCommand(object obj)
        {
            if (Username != "admin" && CurrentUser != null)
            {
                return true;
            }
            return false;
        }

        private bool CanExecuteRoleAddCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteRoleGroupCommand(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
