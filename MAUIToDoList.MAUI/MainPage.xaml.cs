namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        //TODO: Get these events into commands on the viewmodel
        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            context.ToDoItems = e.Value ? context.GetAllToDoItems() : context.GetIncompleteToDoItems();
            this.list.SelectedItem = null;
        }
    }
}