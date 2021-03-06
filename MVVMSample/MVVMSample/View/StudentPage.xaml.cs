using MVVMSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMSample.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentViewModel ViewModel { get;  private set; }
        public StudentPage(StudentViewModel studentViewModel)
        {
            InitializeComponent();
            ViewModel = studentViewModel;
            this.BindingContext = ViewModel;
        }
    }
}