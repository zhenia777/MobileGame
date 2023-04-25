using MobileGame.Domain.Entity;
using MobileGame.Models;
using MobileGame.Services.RepositoryService;
using MobileGame.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace MobileGame.ViewModels
{
    internal class GameResultPageViewModel : ViewModelBase
    {
        private readonly IRepository repository;
        public GameResultPageViewModel(INavigationService navigationService,
                                       IRepository repository)
            : base(navigationService)
        {
            this.repository = repository;
        }

        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        //private int score;
        //public int Score
        //{
        //    get => score;
        //    set => SetProperty(ref score, value);
        //}
        private int result;
        public int Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var theBest = repository.GetAll().OrderBy(x=> x.Score).FirstOrDefault();
            if(theBest == null)
            {
                return;
            }

            Time = $"{theBest.Minutes}:{theBest.Seconds}";
            Result = theBest.Score;

        }

        private ICommand navigateToPlayCommandM;
        public ICommand NavigateToPlayCommandM
        {
            get => navigateToPlayCommandM ??= new DelegateCommand(() =>
            NavigationService.NavigateAsync(nameof(MainPageView)));
        }
    }
}
