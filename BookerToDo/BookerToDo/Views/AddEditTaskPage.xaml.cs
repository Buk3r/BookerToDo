using BookerToDo.ViewModels;

namespace BookerToDo.Views
{
    public partial class AddEditTaskPage : BaseContentPage
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