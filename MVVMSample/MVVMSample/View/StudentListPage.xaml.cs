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
    public partial class StudentListPage : ContentPage
    {
        public StudentListPage()
        {
           InitializeComponent();
             BindingContext = new StudentListViewModel{Navigation = this.Navigation};
        }
    }
}