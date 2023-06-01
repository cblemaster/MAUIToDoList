using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        //TODO: 1) Add functionality
        
        
        //      2) Delete functionality
        //      3) Save functionality
        //      4) Get events into commands on the viewmodel (see code behind; not sure if there is a command for checkedchanged
        //      5) Dependency injection - remember the main page won't compile w/o a parameter-less constructor
        //      6) Move connectionstring out of datacontext and into a config, secrets, etc.


        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            context.DisplayedToDoItems = e.Value
                ? context.ToDoItems
                : new ObservableCollection<ObservableToDoItem>(context.ToDoItems.Where(t => !t.IsComplete));
            this.list.SelectedItem = null;
        }
    }
}