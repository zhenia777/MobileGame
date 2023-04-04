using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MobileGame.Controls
{
	public partial class SceneCar : ContentView
	{
        private List<VisualElement> elements;
        private double userCarSpeedX = 6;
        private double userCarSpeedY = 8;

        private double npcCarSpeedY = 2;

        private readonly double S; 
        private readonly double V; 
        private readonly uint T;

        private readonly Random random;

        public SceneCar ()
		{
			InitializeComponent ();
            elements = new List<VisualElement>
            {
                evilCar1, evilCar2
            };
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

            S = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            T = 5000;
            V = S / T;

            random = new Random();

            //elements.First().TranslateTo(0, S, T - 500);
            Device.StartTimer(TimeSpan.FromMilliseconds(T), AnimationNPCMove);
            //Device.StartTimer(TimeSpan.FromMilliseconds(33), NPCMove);

        }


        private bool AnimationNPCMove()
        {

            var car = elements[random.Next(0, elements.Count)];

            car.TranslationY = -200;
            car.TranslateTo(car.TranslationX, S, T-500);

            return IsGameContinue;
        }
        private bool NPCMove()
        {

            elements.ForEach(car => car.TranslationY +=npcCarSpeedY);
            
            elements.Where(car => car.TranslationY > DeviceDisplay.MainDisplayInfo.Height/DeviceDisplay.MainDisplayInfo.Density).ForEach(car=> car.TranslationY =-car.Height );
            Debug.WriteLine($"{elements[0].TranslationY} {DeviceDisplay.MainDisplayInfo.Height/ DeviceDisplay.MainDisplayInfo.Density}");
            return IsGameContinue;
        }


        
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {

            var rect = new Rectangle(new Point(userCar.X + userCar.TranslationX, userCar.Y + userCar.TranslationY), userCar.Bounds.Size);

            VisualElement res = null;// elements.FirstOrDefault(x => x.Bounds.IntersectsWith(userCar.Bounds));


            //foreach (var item in elements)
            //{
            //    if (item.Bounds.IntersectsWith(rect))
            //    {
            //        Debug.WriteLine($"x:{rect.X:0.000} Y:{rect.Y:0.000}");

            //        //Console.WriteLine();
            //    }
            //}
            //Debug.WriteLine($"x:{userCar.X:0.000} Y:{userCar.Y:0.000}");
            if (res != null)
            {
                if (IntersectsCommand?.CanExecute(null) ?? false)
                {
                    IntersectsCommand.Execute(null);
                }
            }

            UserCarMove(e.Reading.Acceleration.X, e.Reading.Acceleration.Y);
            //TODO: Додати властивості чутливості сенсору

        }

        public ICommand IntersectsCommand
        {
            get => (ICommand)GetValue(IntersectsCommandProperty);
            set => SetValue(IntersectsCommandProperty, value);
        }
        public static readonly BindableProperty IntersectsCommandProperty = BindableProperty.Create(
            nameof(IntersectsCommand),
            typeof(ICommand),
            typeof(SceneCar),
            defaultValue: default);
        public bool IsGameContinue
        {
            get => (bool)GetValue(IsGameContinueProperty);
            set => SetValue(IsGameContinueProperty, value);
        }
        public static readonly BindableProperty IsGameContinueProperty = BindableProperty.Create(
            nameof(IsGameContinue),
            typeof(bool),
            typeof(SceneCar),
            defaultValue: true);

        private void UserCarMove(double acX, double acY)
        {
            if (acX > 0.4)
            {
                userCar.TranslationX -= userCarSpeedX;
            }
            else if (acX < -0.4)
            {
                userCar.TranslationX += userCarSpeedX;
            }

            if (acY > 0.1)
            {
                userCar.TranslationY += userCarSpeedY;
            }
            else if (acY < -0.1)
            {
                userCar.TranslationY -= userCarSpeedY;
            }
        }
    }
}