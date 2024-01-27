using BookerToDo.ViewModels;

namespace BookerToDo.Views
{
    public partial class MainListPage : BaseContentPage
    {
        public MainListPage()
        {
            InitializeComponent();

            BindingContext = new MainListPageViewModel();
        }
    }
}