using MobileGame.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileGame.ViewModels
{
    internal class PlayPageViewModel : ViewModelBase
    {

        public PlayPageViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            //Title = "...";
            
        }

        private List<LifeModel> lifeCollection;
        public List<LifeModel> LifeCollection
        {
            get => lifeCollection;
            set => SetProperty(ref lifeCollection, value);
        }
        private int score;
        public int Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }
        private bool isGameContinue = true;
        public bool IsGameContinue
        {
            get => isGameContinue;
            set => SetProperty(ref isGameContinue, value);
        }

        private ICommand intersectsCommand;
        public ICommand IntersectsCommand
        {
            get => intersectsCommand ??= new DelegateCommand(() => IsGameContinue = false);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            LifeCollection = new List<LifeModel> 
            {
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
            };
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Accelerometer.Start(SensorSpeed.Game); ;
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Accelerometer.Stop();
        }
    }
}
