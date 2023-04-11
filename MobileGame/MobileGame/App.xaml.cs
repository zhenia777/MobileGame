using MobileGame.ViewModels;
using MobileGame.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGame
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {


            //MainPage = new MainPage();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            DeviceDisplay.KeepScreenOn = true;
            //NavigationService.NavigateAsync(nameof(MainPageView));
            NavigationService.NavigateAsync(nameof(PlayPageView));
            //NavigationService.NavigateAsync(nameof(PlayResultPageView));
        }

        protected override void RegisterTypes(IContainerRegistry conteinerRegistry)
        {
            conteinerRegistry.RegisterForNavigation<MainPageView, MainPageViewModel>();
            conteinerRegistry.RegisterForNavigation<PlayPageView, PlayPageViewModel>();
            conteinerRegistry.RegisterForNavigation<PlayResultPageView, PlayResultPageViewModel>();

        }

    }
}
