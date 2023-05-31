namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        //TODO: 1) Delete functionality
        //      2) Add functionality
        //      3) Save functionality
        //      4) Get events into commands on the viewmodel (see code behind; not sure if there is a command for checkedchanged
        //      5) Dependency injection - remember the main page won't compile w/o a parameter-less constructor
        
        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            context.ToDoItems = e.Value ? context.GetAllToDoItems() : context.GetIncompleteToDoItems();
            this.list.SelectedItem = null;
        }
    }
}