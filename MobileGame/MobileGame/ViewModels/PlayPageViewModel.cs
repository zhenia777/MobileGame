using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        }


        private double x;
        public double X
        {
            get => x;
            set => SetProperty(ref x, value);
        }

        private double y;
        public double Y
        {
            get => y;
            set => SetProperty(ref y, value);
        }
        private ICommand intersectsCommand;
        public ICommand IntersectsCommand
        {
            get => intersectsCommand ??= new DelegateCommand(() => Debug.WriteLine("Yes!!"));
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
