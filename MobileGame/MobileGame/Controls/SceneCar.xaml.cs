using MobileGame.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        private double userCarSpeedX = 12;
        private double userCarSpeedY = 4;

        //private double npcCarSpeedY = 2;
        private readonly double S;
        private readonly double V;
        private readonly uint T;
        private int score = 0;
        private bool isIntersect = false;
        private int outStep = -500;
        


        private readonly Random random;
        private VisualElement activeEvilCar;

        public SceneCar ()
		{

            //activeEvilCar.TranslationY -= 500;
            
			InitializeComponent ();
            elements = new List<VisualElement>
            {
                evilCar1, evilCar2
            };
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            S = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            T = 4000;
            V = S / T;

            random = new Random();

            //elements.First().TranslateTo(0, S, T - 500);
            Device.StartTimer(TimeSpan.FromMilliseconds(T), AnimationNPCMove);
            //Device.StartTimer(TimeSpan.FromMilliseconds(33), NPCMove);

        }


        private bool AnimationNPCMove()
        {
            if (!IsGameContinue)
            {
                return false;
            }
            isIntersect = false;
            activeEvilCar = elements[random.Next(0, elements.Count)];

            activeEvilCar.TranslationY = outStep;
            activeEvilCar.TranslationX = random.Next(-30, 30);
            activeEvilCar.TranslateTo(activeEvilCar.TranslationX, S, (uint)(T-outStep - score));
            Score = (score +=50);
            
            return IsGameContinue;
        }
        //private bool NPCMove()
        //{

        //    elements.ForEach(car => car.TranslationY +=npcCarSpeedY);

        //    elements.Where(car => car.TranslationY > DeviceDisplay.MainDisplayInfo.Height/DeviceDisplay.MainDisplayInfo.Density).ForEach(car=> car.TranslationY =-car.Height );
        //    Debug.WriteLine($"{elements[0].TranslationY} {DeviceDisplay.MainDisplayInfo.Height/ DeviceDisplay.MainDisplayInfo.Density}");
        //    return IsGameContinue;
        //}


        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            if( userCar is null || activeEvilCar is null )
            {
                return;
            }


            if (IntersectsChecker.Check(userCar, activeEvilCar) && !isIntersect)
            {
                isIntersect = true;

                if (IntersectsCommand?.CanExecute(null) ?? false )
                {
                    double t_X = activeEvilCar.TranslationX;
                    double t_Y = activeEvilCar.TranslationY;
                    
                    IntersectsCommand.Execute(null);

                    activeEvilCar.CancelAnimations();

                    if (LifeCount == 1)
                    {
                        activeEvilCar.TranslationX = t_X;
                        activeEvilCar.TranslationY = t_Y;
                    }
                    else
                    {
                        activeEvilCar.TranslationX = outStep;
                        activeEvilCar.TranslationY = outStep;
                    }
                }
            }

            UserCarMove(e.Reading.Acceleration.X, e.Reading.Acceleration.Y);
          

        }
        
       

        public int Score
        {
            get => (int)GetValue(ScoreProperty);
            set => SetValue(ScoreProperty, value);
        }
        public static readonly BindableProperty ScoreProperty = BindableProperty.Create(
           nameof(Score),
           typeof(int),
           typeof(SceneCar),
           defaultBindingMode: BindingMode.TwoWay,
           defaultValue: default);

        public int LifeCount
        {
            get => (int)GetValue(LifeCountProperty);
            set => SetValue(LifeCountProperty, value);
        }
        public static readonly BindableProperty LifeCountProperty = BindableProperty.Create(
           nameof(LifeCount),
           typeof(int),
           typeof(SceneCar),
           defaultBindingMode: BindingMode.TwoWay,
           defaultValue: default);

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
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: true);

        private void UserCarMove(double acX, double acY)
        {
            double w = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double h = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            if (acX > 0.4 && userCar.TranslationX > -w + userCar.Width+30)
            {
                
                userCar.TranslationX -= userCarSpeedX;
            }
            else if (acX < -0.4 && userCar.TranslationX < w/2 -userCar.Width*2)
            {
                userCar.TranslationX += userCarSpeedX;
            }

            if (acY > 0.1 && userCar.TranslationY != 0 )
            {
                userCar.TranslationY += userCarSpeedY;
            }
            else if (acY < -0.1 && userCar.TranslationY  >- h / 2 + userCar.Height / 2)
            {
                userCar.TranslationY -= userCarSpeedY;
            }
        }
    }
}