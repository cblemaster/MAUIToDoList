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
            context.FilteredToDoItems = e.Value
                ? context.ToDoItems
                : new ObservableCollection<ObservableToDoItem>(context.ToDoItems.Where(t => !t.IsComplete));
            this.list.SelectedItem = null;
        }

        private void hasduedateswitch_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //if (e.Value)    // checkbox checked
            //{                
            //    //  Datepicker is visible - ok, handled in the xaml
            //    //  Today's date is selected in the Datepicker - ok

            //    //  Due date on list item is today - ok
            //    //  Due date on the details is today - ok
            //}
            //else            // checkbox unchecked
            //{
            //    //  Datepicker is not visible - ok, handled in the xaml
            //    //  Due date on the list item is 'None'
            //}

            MainPageModel model = (MainPageModel)this.BindingContext;
            if (model != null && model.SelectedToDoItem != null)
            {
                model.SelectedToDoItem.DueDate = null;
            }           
        }

        // displaying data from the db
        //
        //  Due date == null
        //  checkbox is unchecked
        //  Datepicker is not visible
        //  Due date on list item is 'None'
        //  
        //  Due date != null
        //  checkbox is checked
        //  Datepicker is visible
        //  Datepicker date is due date
        //  Due date on list item is same as datepicker



    }
}