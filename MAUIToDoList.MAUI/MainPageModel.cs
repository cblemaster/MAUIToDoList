using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIToDoList.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUIToDoList.MAUI
{
    public class MainPageModel : ObservableObject
    {
        private readonly SimpleToDoListContext _context = new();
        private ObservableCollection<ToDoItem> _toDoItems = new();
        private ToDoItem? _selectedToDoItem = null;
        private bool _isAdding;

        public MainPageModel()
        {
            this.ToDoItems = this.GetAllToDoItems();
            this.AddCommand = new AsyncRelayCommand(this.Add);
        }        

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get => this._toDoItems;
            set => this.SetProperty(ref this._toDoItems, value);
        }        

        public ToDoItem? SelectedToDoItem
        {
            get => this._selectedToDoItem;
            set => this.SetProperty(ref this._selectedToDoItem, value);
        }        

        public bool IsAdding
        {
            get => this._isAdding;
            set => this.SetProperty(ref this._isAdding, value);
        }

        public ICommand AddCommand { get; }        

        public ObservableCollection<ToDoItem> GetAllToDoItems() => 
            new(this._context.ToDoItems.OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        public ObservableCollection<ToDoItem> GetIncompleteToDoItems() => 
            new(this._context.ToDoItems.Where(t => !t.IsComplete).OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        private async Task Add()
        {
            await Task.Run(() =>
            {
                this.IsAdding = true;
                
                ToDoItem itemToAdd = new() { Name = string.Empty };
                this.ToDoItems.Add(itemToAdd);
                this.SelectedToDoItem = itemToAdd;                
            });
        } 
    }
}
