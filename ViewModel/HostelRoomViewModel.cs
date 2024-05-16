using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Repositories;
using HostelControlService.Utils;
using HostelControlService.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostelControlService.ViewModel
{
    internal class HostelRoomViewModel: ViewModelBase
    {
        #region Fields
        private string _roomName;
        private string _description;
        private int _memberCount;
        private int _roomLevel;
        private bool _status;
        private IEnumerable<HostelRoomView> _hostelRooms;

        public string RoomName 
        { 
            get => _roomName;
            set 
            { 
                _roomName = value;
                OnPropertyChanged(nameof(RoomName));
            }
        }
        public string Description 
        { 
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            } 
        }
        public int MemberCount 
        { 
            get => _memberCount;
            set
            {
                _memberCount = value;
                OnPropertyChanged(nameof(MemberCount));
            } 
        }
        public int RoomLevel 
        { 
            get => _roomLevel;
            set
            {
                _roomLevel = value;
                OnPropertyChanged(nameof(RoomLevel));
            }
        }
        public bool Status 
        { 
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public IEnumerable<HostelRoomView> HostelRooms 
        { 
            get => _hostelRooms;
            set
            {
                _hostelRooms = value;
                OnPropertyChanged(nameof(HostelRooms));
            } 
        }

        private IRoomRepository roomRepository;
        private IUserRepository userRepository;
        #endregion

        #region Commands
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        #endregion

        #region Constructor
        public HostelRoomViewModel()
        {
            roomRepository = new RoomRepository();
            userRepository = new UserRepository();

            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        }

        #endregion

        #region Methods
        private void ExecuteAddCommand(object obj)
        {
        }

        private void ExecuteEditCommand(object obj)
        {
            throw new NotImplementedException();
        }


        private void ExecuteDeleteCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteAddCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteEditCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteDeleteCommand(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
