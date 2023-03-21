using MobileGame.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Device.StartTimer(TimeSpan.FromSeconds(1), timerHandler);
        }
        //bool timerHandler()
        //{
        //    Task.Run(async () =>
        //    {
        //        await btn.ScaleTo(1.5, 500);
        //        await btn.ScaleTo(1, 500);
        //    });
        //    return true;
        //}
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var btn = (Button)sender;

        //}
    }
}
