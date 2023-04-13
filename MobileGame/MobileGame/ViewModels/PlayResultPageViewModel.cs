using MobileGame.Models;
using MobileGame.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileGame.ViewModels
{
    internal class PlayResultPageViewModel : ViewModelBase
    {
        public PlayResultPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        private int score;
        public int Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }
        private int result;
        public int Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var result = parameters.GetValue<PlayResultModel>(nameof(PlayResultModel));
            Score = result.Score;
            Time = $"{result.Minutes}" + ":" +  $"{result.Seconds}";
        }
        private ICommand navigateToPlayCommandM;
        public ICommand NavigateToPlayCommandM
        {
            get => navigateToPlayCommandM ??= new DelegateCommand(() =>
            NavigationService.NavigateAsync(nameof(MainPageView)));
        }

        private ICommand navigateToPlayCommandP;
        public ICommand NavigateToPlayCommandP
        {
            get => navigateToPlayCommandP ??= new DelegateCommand(() =>
            NavigationService.NavigateAsync(nameof(PlayPageView)));
        }
       
    }
}
