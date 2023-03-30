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
    internal class PlayPageViewModel : ViewModelBase
    {
        public PlayPageViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.Game);
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
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            if (e.Reading.Acceleration.X > 0.4)
            {
                X -= 6;
            }
            else if (e.Reading.Acceleration.X < -0.4)
            {
                X += 6;
            }

            if (e.Reading.Acceleration.Y > 0.1)
            {
                Y += 8;
            }
            else if (e.Reading.Acceleration.Y < -0.1)
            {
                Y -= 8;
            }

        }


        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Accelerometer.Stop();

            base.OnNavigatedFrom(parameters);
        }

    }
}
