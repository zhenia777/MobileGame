using MobileGame.ViewModels;
using MobileGame.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGame
{
    public partial class App 
    {
        public App(IPlatformInitializer initializer)
            :base(initializer)
        {
            

            //MainPage = new MainPage();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(nameof(PlayPageView));
        }

        protected override void RegisterTypes(IContainerRegistry conteinerRegistry)
        {
            conteinerRegistry.RegisterForNavigation<PlayPageView, PlayPageViewModel>();
        }

    }
}
