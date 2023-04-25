using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileGame.Helpers
{
    internal static class IntersectsChecker
    {
        public static bool Check(VisualElement element1, VisualElement element2)
        {
            var rect1 = new Rectangle()
            {
                Location = new Point(element1.X + element1.TranslationX, element1.Y + element1.TranslationY), 
                Size = element1.Bounds.Size
            };

            var rect2 = new Rectangle()
            {
                Location = new Point(element2.X + element2.TranslationX, element2.Y + element2.TranslationY),
                Size = element2.Bounds.Size
            };

            return rect1.IntersectsWith(rect2);
        }
    }
}
