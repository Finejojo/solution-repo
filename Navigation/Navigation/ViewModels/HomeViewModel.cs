using Navigation.Commands;
using Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Navigation.ViewModels
{
    public class AccountViewModel:ViewModelBase
    {

        public string WelcomeMessage => "Welcome to my application";

        public ICommand NavigateAccountCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateAccountCommand(navigationStore);
        }
    }
}
