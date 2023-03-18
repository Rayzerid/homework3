using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands
{
    public class DeleteCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        public DeleteCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _globalViewModel.StudentInfos.RemoveAt(_globalViewModel.SelectedItemIndex);
            }
            catch
            {
                MessageBox.Show("Элемент не был выбран!");
            }
        }
    }
}
