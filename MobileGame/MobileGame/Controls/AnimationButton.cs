using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileGame.Controls
{
    class AnimationButton : Button
    {
        private void Animation()
        {
            Task.Run(async () =>
            {
                uint animationSpan = 500;
                while (EnableAnimation)
                {
                    await this.ScaleTo(1, animationSpan);
                    await this.ScaleTo(1.5, animationSpan);
                }
                await this.ScaleTo(1, animationSpan);
                Scale = 1;

            });
        }

        public bool EnableAnimation
        {
            get => (bool)GetValue(EnableAnimationProperty);
            set => SetValue(EnableAnimationProperty, value);
        }
        public static readonly BindableProperty EnableAnimationProperty = BindableProperty.Create(
            nameof(EnableAnimation),
            typeof(bool),
            typeof(AnimationButton),
            defaultValue: false,
            propertyChanging: OnEnableAnimationChanging);

        private static void OnEnableAnimationChanging(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AnimationButton button)
            {
                button.Animation();
            }
        }
    }
}
