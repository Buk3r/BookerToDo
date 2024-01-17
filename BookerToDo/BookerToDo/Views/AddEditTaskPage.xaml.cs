using BookerToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookerToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditTaskPage : ContentPage
    {
        public AddEditTaskPage()
        {
            InitializeComponent();

            BindingContext = new AddEditTaskPageViewModel();
        }
    }
}