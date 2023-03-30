using MobileGame.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MobileGame.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
           
        }

        private ICommand navigateToPlayCommand;
        public ICommand NavigateToPlayCommand
        {
            get => navigateToPlayCommand ??= new DelegateCommand(()=> 
            NavigationService.NavigateAsync(nameof(PlayPageView)));
        }

    }
}
