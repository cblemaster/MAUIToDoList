using MAUIToDoList.Data;
using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly SimpleToDoListContext _context;
        
        public MainPage()
        {
            this.InitializeComponent();

            this._context = new ();

            this.ToDoItems = 
                new ObservableCollection<ToDoItem>
                    (this._context
                        .ToDoItems
                            .OrderByDescending(X => X.DueDate)
                            .ThenBy(x => x.Name)
                    );
            
            this.BindingContext = this;
        }

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }
    }
}