using homework.Model;
using homework.Structs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class ResultViewModel : ViewModelBase
    {
        GlobalViewModel _globalViewModel;
        public ResultViewModel(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        private ObservableCollection<StudentInfo> resultStudent = new ObservableCollection<StudentInfo>();

        public ObservableCollection<StudentInfo> ResultStudent
        {
            get 
            {
                FileProcess fileProcess = new FileProcess(_globalViewModel);
                resultStudent = fileProcess.ResultStudent(_globalViewModel.StudentInfos);
                return resultStudent ;
            }
            set { resultStudent = value; }
        }
    }
}
