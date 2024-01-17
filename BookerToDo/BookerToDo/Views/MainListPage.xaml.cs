using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookerToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainListPage : ContentPage
    {
        public MainListPage()
        {
            InitializeComponent();

            todoList.ItemsSource = new List<string>
            {
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
                "string",
            };
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddEditTaskPage());
        }
    }
}