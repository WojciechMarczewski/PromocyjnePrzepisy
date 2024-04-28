namespace PromocyjnePrzepisy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            if (Shell.Current.CurrentPage.Title is "MainPage") { return; }
            Task.Run(async () => await Shell.Current.GoToAsync("//MainPage"));
        }
        private void ShoppingList_Clicked(object sender, EventArgs e)
        {
            if (Shell.Current.CurrentPage.Title is "ShoppingListPage") { return; }
            Task.Run(async () => await Shell.Current.GoToAsync("//ShpngListPage"));
        }
        private void SearchPage_Clicked(object sender, EventArgs e)
        {
            if (Shell.Current.CurrentPage.Title is "SearchPage") { return; }
            Task.Run(async () => await Shell.Current.GoToAsync("//SearchPage"));
        }
    }
}
