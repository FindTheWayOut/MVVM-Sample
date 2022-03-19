using MVVMSample.Model;
using System.ComponentModel;

namespace MVVMSample.ViewModel
{
    public class StudentViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        StudentListViewModel studentLVM;

        public Student Student { get; private set; }

        public StudentViewModel() => Student = new Student();

        public StudentListViewModel ListViewModel
        {
            get { return studentLVM; }
            set
            {
                if (studentLVM != value)
                {
                    studentLVM = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return Student.Name; }
            set
            {
                if (Student.Name != value)
                {
                    Student.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Group 
        {
            get { return Student.Group; }
            set
            {
                if (Student.Group!= value)
                {
                    Student.Group = value;
                    OnPropertyChanged("Group");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Group.Trim())));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
