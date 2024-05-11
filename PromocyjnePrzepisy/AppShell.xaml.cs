namespace PromocyjnePrzepisy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        private void Close_Clicked(object sender, EventArgs e)
        {
            Application.Current?.Quit();
        }
    }
}
