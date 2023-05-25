using CommunityToolkit.Mvvm.ComponentModel;
using MAUIToDoList.Data;
using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public class MainPageModel : ObservableObject
    {
        private readonly SimpleToDoListContext _context = new();
        private ObservableCollection<ToDoItem> _toDoItems = new();

        public MainPageModel() => this.ToDoItems = this.GetAllToDoItems();

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get => this._toDoItems;
            set => this.SetProperty(ref this._toDoItems, value);
        }

        public ObservableCollection<ToDoItem> GetAllToDoItems() => 
            new(this._context.ToDoItems.OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        public ObservableCollection<ToDoItem> GetIncompleteToDoItems() => 
            new(this._context.ToDoItems.Where(t => !t.IsComplete).OrderBy(t => t.DueDate).ThenBy(t => t.Name));

    }
}
