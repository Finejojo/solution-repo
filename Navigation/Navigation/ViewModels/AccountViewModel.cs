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
    public class AccountViewModel: ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my account";

        public ICommand NavigateHomeCommand { get; }
        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }

    }
}
