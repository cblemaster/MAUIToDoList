using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            context.FilteredToDoItems = e.Value
                ? context.ToDoItems
                : new ObservableCollection<ObservableToDoItem>(context.ToDoItems.Where(t => !t.IsComplete));
            this.list.SelectedItem = null;
        } 
    }
}