using MobileGame.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGame.ViewModels
{
    internal class PlayResultPageViewModel : ViewModelBase
    {
        public PlayResultPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var result = parameters.GetValue<PlayResultModel>(nameof(PlayResultModel));
        }

    }
}
