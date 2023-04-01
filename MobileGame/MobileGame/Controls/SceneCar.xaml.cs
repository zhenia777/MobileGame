using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGame.Controls
{
	public partial class SceneCar : ContentView
	{
        List<VisualElement> elements;
		public SceneCar ()
		{
			InitializeComponent ();
            elements = new List<VisualElement>
            {
                evilCar1, evilCar2
            };
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }
        
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            VisualElement res = null;// elements.FirstOrDefault(x => x.Bounds.IntersectsWith(userCar.Bounds));
            foreach (var item in elements)
            {
                if (item.Bounds.IntersectsWith(new Rectangle(new Point(userCar.X, userCar.Y), userCar.Bounds.Size)))
                {
                    Debug.WriteLine($"x:{userCar.X:0.000} Y:{userCar.Y:0.000}");

                    Console.WriteLine();
                }
            }
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

        private void UserCarMove(double acX, double acY)
        {
            if (acX > 0.4)
            {
                userCar.TranslationX -= 6;
            }
            else if (acX < -0.4)
            {
                userCar.TranslationX += 6;
            }

            if (acY > 0.1)
            {
                userCar.TranslationY += 8;
            }
            else if (acY < -0.1)
            {
                userCar.TranslationY -= 8;
            }
        }
    }
}