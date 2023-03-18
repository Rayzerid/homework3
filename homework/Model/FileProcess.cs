using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using homework.Structs;
using homework.ViewModel;

namespace homework.Model
{
    public class FileProcess
    {
        GlobalViewModel _globalViewModel;
        public FileProcess(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        public void SaveToFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<StudentInfo>));
            formatter.Serialize(fs, _globalViewModel.StudentInfos);
            fs.Close();
        }

        public ObservableCollection<StudentInfo> ReadFromFile(string path)
        {
            ObservableCollection<StudentInfo> person;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<StudentInfo>));
            object result = formatter.Deserialize(fs);
            person = (ObservableCollection<StudentInfo>)result;
            fs.Close();
            return person;
        }
        public ObservableCollection<StudentInfo> ResultStudent(ObservableCollection<StudentInfo> studentInfos)
        {
            DateTime dateTime = DateTime.Now;
            return studentInfos = new ObservableCollection<StudentInfo>(_globalViewModel.StudentInfos.Where(x => x.Birthday.Month == dateTime.Month));
        }
    }
}
