using HostelControlService.Interface;
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
    internal class OrderViewModel: ViewModelBase
    {
        #region Fields
        private string _name;
        private string _description;
        private bool _status;
        private string _username;
        private int _roomId;

        private IEnumerable<OrderView> ordersList;

        private IUserRepository userRepository;
        private IOrderRepository orderRepository;

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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
        public bool Status 
        { 
            get => _status;
            set
            { 
                _status = value;
                OnPropertyChanged(nameof(Status));
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
        public int RoomId 
        { 
            get => _roomId;
            set 
            { 
                _roomId = value;
                OnPropertyChanged(nameof(RoomId));
            } 
        }
        public IEnumerable<OrderView> OrdersList
        {
            get => ordersList;
            set
            {
                ordersList = value;
                OnPropertyChanged(nameof(OrdersList));
            }
        }
        #endregion

        #region Commands
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand ClearCommand { get; }
        #endregion

        #region Constructor
        public OrderViewModel()
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            LoadOrder();

            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteGroupCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteGroupCommand);
            RefreshCommand = new ViewModelCommand(ExecuteRefreshCommand, CanExecuteGroupCommand);
            ClearCommand = new ViewModelCommand(ExecuteClearCommand, CanExecuteGroupCommand);
        }
        #endregion

        #region Methods
        private void LoadOrder()
        {

        }

        private void ExecuteAddCommand(object obj) 
        {


        }

        private void ExecuteEditCommand(object obj) 
        {
            
        }

        private void ExecuteDeleteCommand(object obj) 
        {
            
        }

        private void ExecuteRefreshCommand(object obj)
        {

        }

        private void ExecuteClearCommand(object obj) 
        {
            
        }

        private bool CanExecuteAddCommand(object obj) 
        {
            if(Username == null)
            {
                return true;
            }
            return false;
        }

        private bool CanExecuteGroupCommand(object obj) 
        {
            if(Username != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
