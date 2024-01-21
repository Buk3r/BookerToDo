namespace BookerToDo.Views
{
    public partial class MainListPage : BaseContentPage
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