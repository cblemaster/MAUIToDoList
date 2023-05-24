using MAUIToDoList.Data;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => this.InitializeComponent();

        //TODO: Get these events into commands on the viewmodel
        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MainPageModel context = ((MainPageModel)this.BindingContext);
            if (e.Value)
            {
                context.ToDoItems = context.GetAllToDoItems();
            }
            else
            {
                context.ToDoItems = context.GetIncompleteToDoItems();
            }
            //context.SelectedToDo = null;
            this.list.SelectedItem = null;
        }

        //private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MainPageModel context = ((MainPageModel)this.BindingContext);
        //    context.SelectedToDo = (ToDoItem)e.CurrentSelection[0];
        //}
    }
}