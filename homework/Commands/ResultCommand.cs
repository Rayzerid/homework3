using System;
using homework.ViewModel;
using homework.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands
{
    public class ResultCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        public ResultCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override async void Execute(object parameter)
        {
            try
            {
                var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                var dialogWindowViewModel = new ResultViewModel(_globalViewModel);
                await displayRootRegistry.ShowModalPresentation(dialogWindowViewModel);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
