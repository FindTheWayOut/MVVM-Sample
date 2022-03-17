using MVVMSample.Model;
using MVVMSample.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMSample.ViewModel
{
    public class StudentListViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<StudentViewModel> Students { get; set; }
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        public ICommand CreateStudentCommand { protected set; get; }
        public ICommand DeleteStudentCommand { protected set; get; }
        public ICommand SaveStudentCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        StudentViewModel selectedStudent;
 
        public INavigation Navigation { get; set;}
 
        public StudentListViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();
            CreateStudentCommand = new Command(CreateStudent);
            DeleteStudentCommand = new Command(DeleteStudent);
            SaveStudentCommand = new Command(SaveStudent);
            BackCommand = new Command(Back);
        }
 
        public StudentViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    StudentViewModel tempStudent = value;
                    selectedStudent = null;
                    OnPropertyChanged("SelectedStudent");
                    Navigation.PushAsync(new StudentPage(tempStudent));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
 
        private void CreateStudent()
        {
            Navigation.PushAsync(new StudentPage(new StudentViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveStudent(object studentObj)
        {
            StudentViewModel student = studentObj as StudentViewModel;
            if (student != null && student.IsValid && !Students.Contains(student))
            {
                Students.Add(student);
                Back();
            }
        }
        private void DeleteStudent(object StudentObject)
        {
            StudentViewModel student = StudentObject as StudentViewModel;
            if (student != null)
            {
                Students.Remove(student);
                Back();
            }
        }
    }
}
