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
            Timer();
        }

        private List<LifeModel> lifeCollection;
        public List<LifeModel> LifeCollection
        {
            get => lifeCollection;
            set => SetProperty(ref lifeCollection, value);
        }

        private int life = 3;
        public int Life
        {
            get => life;
            set => SetProperty(ref life, value);
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

        int seconds = 0;
        int minutes = 0;
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Device.StartTimer(TimeSpan.FromSeconds(1), () => { seconds++; return true; });
            if (seconds > 60)
            {
                minutes += 1;
                seconds = 0;
            }
            
            //Time = $"{minutes}" + ":" + $"{seconds}";

            LifeCollection = new List<LifeModel> 
            {
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
            };
        }
        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public void Timer()
        {
            Time = $"{minutes}" + ":" + $"{seconds}";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Accelerometer.Start(SensorSpeed.Game); 
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Accelerometer.Stop();
        }
    }
}
