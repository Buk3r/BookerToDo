using BookerToDo.ViewModels;

namespace BookerToDo.Views
{
    public partial class AddEditTaskPage : BaseContentPage
    {
        public AddEditTaskPage()
        {
            InitializeComponent();

            BindingContext = new AddEditTaskPageViewModel();
        }
    }
}