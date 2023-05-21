namespace MAUIToDoList.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            this.MainPage = new AppShell();
        }
    }
}