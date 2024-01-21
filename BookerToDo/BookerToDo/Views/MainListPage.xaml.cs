using BookerToDo.ViewModels;
using System.Collections.Generic;

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