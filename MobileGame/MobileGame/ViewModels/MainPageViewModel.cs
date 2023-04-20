using MobileGame.Domain;
using MobileGame.Helpers;
using MobileGame.Services.AndroidDbPathService;
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
        private readonly IPath pathService;
        public MainPageViewModel(INavigationService navigationService,
                                 IPath pathService)
            : base(navigationService)
        {
            this.pathService = pathService;
        }

        private ICommand navigateToPlayCommand;
        public ICommand NavigateToPlayCommand
        {
            get => navigateToPlayCommand ??= new DelegateCommand(()=> 
            NavigationService.NavigateAsync(nameof(PlayPageView)));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            string path = pathService.GetDatabasePath(Constants.DATABASE_FILENAME);
            using (ApplicationContext db = new(path)){}
        }


    }
}
