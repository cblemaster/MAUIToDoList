namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        //TODO: 1) Delete functionality
        //      2) Add functionality
        //      3) Edit functionality
        //      4) Figure out why updating a name or due date in details isn't immediately reflected in the list
        //      5) Get events into commands on the viewmodel (see code behind; not sure if there is a command for checkedchanged
        
        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            context.ToDoItems = e.Value ? context.GetAllToDoItems() : context.GetIncompleteToDoItems();
            this.list.SelectedItem = null;
        }
    }
}