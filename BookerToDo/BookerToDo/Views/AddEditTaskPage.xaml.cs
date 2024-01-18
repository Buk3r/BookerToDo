using BookerToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookerToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditTaskPage : ContentPage
    {
        private readonly AddEditTaskPageViewModel _viewModel = new AddEditTaskPageViewModel();

        public AddEditTaskPage()
        {
            InitializeComponent();

            BindingContext = _viewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return _viewModel.OnBackButtonPressed();
        }
    }
}