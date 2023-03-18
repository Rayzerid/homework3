using homework.Structs;
using System;
using System.Collections.ObjectModel;
using System.Data;
using homework.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;

namespace homework.ViewModel
{
    public class GlobalViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand ResultCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand DeleteCommand { get; }

        public GlobalViewModel()
        {
            DeleteCommand = new DeleteCommand(this);
            ClearCommand = new ClearCommand(this);
            ResultCommand = new ResultCommand(this);
            LoadCommand = new LoadCommand(this);
            SaveCommand = new SaveCommand(this);
            AddCommand = new AddCommand(this);
        }

        private ObservableCollection<StudentInfo> studentInfos = new ObservableCollection<StudentInfo>();

        public ObservableCollection<StudentInfo> StudentInfos
        {
            get { return studentInfos; }
            set
            {
                studentInfos = value;
                OnPropertyChanged();
            }
        }

        private int selectedItemIndex;
        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set
            {
                if (selectedItemIndex != value)
                {
                    selectedItemIndex = value;
                    OnPropertyChanged("SelectedItemIndex");
                }
            }
        }

        public ICommand CellEditEndingCommand => new RelayCommand<object>(OnCellEditEnding);

        private void OnCellEditEnding(object e)
        {
            if (e is StudentInfo item)
            {
                studentInfos[selectedItemIndex] = item;
            }
        }

    }
}
