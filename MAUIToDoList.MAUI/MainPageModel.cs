using CommunityToolkit.Mvvm.ComponentModel;
using MAUIToDoList.Data;
using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public class MainPageModel : ObservableObject
    {
        private readonly SimpleToDoListContext _context = new();
        private ObservableCollection<ToDoItem> _toDoItems = new();
        //private ToDoItem? _selectedToDo = null;

        public MainPageModel()
        {
            this.ToDoItems = this.GetAllToDoItems();
        }

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get => _toDoItems;
            set => SetProperty(ref _toDoItems, value);
        }

        //public ToDoItem? SelectedToDo
        //{
        //    get => _selectedToDo;
        //    set => SetProperty(ref _selectedToDo, value);
        //}

        public ObservableCollection<ToDoItem> GetAllToDoItems() => new ObservableCollection<ToDoItem>(this._context.ToDoItems.OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        public ObservableCollection<ToDoItem> GetIncompleteToDoItems() => new ObservableCollection<ToDoItem>(this._context.ToDoItems.Where(t => !t.IsComplete).OrderBy(t => t.DueDate).ThenBy(t => t.Name));

    }
}
