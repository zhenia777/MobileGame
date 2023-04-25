using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileGame.Controls
{
    class AnimationButton1 : Button
    {
        public AnimationButton1()
        {
            this.Clicked += (s, e) => {
                this.ScaleTo(2, 100);
                this.ScaleTo(1, 100);
             
            };
        }
        private void Animation1()
        {
            Task.Run(async () => {});
        }


        public bool EnableAnimation
        {
            get => (bool)GetValue(EnableAnimationProperty);
            set => SetValue(EnableAnimationProperty, value);
        }
        public static readonly BindableProperty EnableAnimationProperty = BindableProperty.Create(
            nameof(EnableAnimation),
            typeof(bool),
            typeof(AnimationButton1),
            defaultValue: false,
            propertyChanging: OnEnableAnimationChanging);

        private static void OnEnableAnimationChanging(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AnimationButton1 button)
            {
                button.Animation1();
            }
        }
    }
}

