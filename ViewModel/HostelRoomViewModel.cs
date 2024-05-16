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
using System.Windows;
using System.Windows.Input;

namespace HostelControlService.ViewModel
{
    internal class HostelRoomViewModel: ViewModelBase
    {
        #region Fields
        private RoomModel _currentroomModel;
        private IEnumerable<RoomModel> _hostelRooms;

        public RoomModel CurrentRoomModel
        {
            get { return _currentroomModel; }
            set 
            { 
                _currentroomModel = value;
                OnPropertyChanged(nameof(CurrentRoomModel));
            }
        }

        public IEnumerable<RoomModel> HostelRooms 
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

            HostelRooms = roomRepository.GetAll();

            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        }

        #endregion

        #region Methods
        private void ExecuteAddCommand(object obj)
        {
            bool isRoomExist = roomRepository.GetByName(CurrentRoomModel.Name) != null;
            if (isRoomExist)
            {
                roomRepository.Add(CurrentRoomModel);

                HostelRooms = roomRepository.GetAll();
            }
            else
            {
                MessageBox.Show("Такая комната уже существует");
            }
        }

        private void ExecuteEditCommand(object obj)
        {
            roomRepository.Edit(CurrentRoomModel);
            HostelRooms = roomRepository.GetAll();
        }



        private bool CanExecuteAddCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteEditCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteDeleteCommand(object obj)
        {
            return true;
        }
        #endregion
    }
}
