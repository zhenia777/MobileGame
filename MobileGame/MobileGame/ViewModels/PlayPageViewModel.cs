using MobileGame.Models;
using MobileGame.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private int life;
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
            set => SetProperty(ref isGameContinue, value, 
                ()=> NavigationService.NavigateAsync(nameof(PlayResultPageView)) );
        }



        private ICommand intersectsCommand;
        public ICommand IntersectsCommand
        {
            get => intersectsCommand ??= new DelegateCommand(() => {

                if (LifeCollection.Count > 1)
                {
                    LifeCollection.Remove(LifeCollection.Last());
                    LifeCollection = new(LifeCollection);
                    return;
                }
                if(LifeCollection.Count == 1)
                {
                    LifeCollection.Remove(LifeCollection.Last());
                    LifeCollection = new(LifeCollection);
                }

                IsGameContinue = false;
            });
        }

        int seconds = 0;
        int minutes = 0;
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                seconds++; 
                if (seconds > 60)
                {
                    minutes += 1;
                    seconds = 0;
                }
                Timer();
                return IsGameContinue;
            });
            

            LifeCollection = new List<LifeModel> 
            {
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
                new() { ImageSource = ImageSource.FromFile("LIFE.png") },
            };

            Life = LifeCollection.Count;

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

            parameters.Add(nameof(PlayResultModel), 
                new PlayResultModel { Minutes = minutes, Seconds = seconds, Score = score});
        }

    }
}
