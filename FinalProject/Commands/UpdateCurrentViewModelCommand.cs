using FinalProject.State.Navigators;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.ProductReceive:
                        _navigator.CurrentViewModel = new ProductReceivesViewModel();
                        break;
                    case ViewType.Product:
                        _navigator.CurrentViewModel = new ProductViewModel();
                        break;
                    case ViewType.Producer:
                        _navigator.CurrentViewModel = new ProducerViewModel();
                        break;
                    case ViewType.Supplier:
                        _navigator.CurrentViewModel = new SupplierViewModel();
                        break;
                    case ViewType.Warehouse:
                        _navigator.CurrentViewModel = new WareHouseViewModel();
                        break;
                }
            }
        }
    }
}
