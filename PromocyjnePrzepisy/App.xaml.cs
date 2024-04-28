namespace PromocyjnePrzepisy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //Temporarily navigate to currently created page at app start
            Task.Run(async () => await Shell.Current.GoToAsync("//ShpngListPage"));

        }
    }
}
