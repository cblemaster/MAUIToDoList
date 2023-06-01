using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIToDoList.Data;
using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPageModel : ObservableObject
    {
        private readonly SimpleToDoListContext _context = new();

        [ObservableProperty]
        private ObservableCollection<ObservableToDoItem> _toDoItems = new();

        [ObservableProperty]
        private ObservableCollection<ObservableToDoItem> _displayedToDoItems = new();

        [ObservableProperty]
        private ObservableToDoItem? _selectedToDoItem = null;

        [ObservableProperty]
        private bool _isAdding;

        public MainPageModel()
        {
            this.ToDoItems = this.GetAllToDoItems();
            this.DisplayedToDoItems = this.ToDoItems;
        }

        public ObservableCollection<ObservableToDoItem> GetAllToDoItems() =>
            new(ConvertToDoItemsToObservable
                (this._context.ToDoItems.OrderBy(t => t.DueDate).ThenBy(t => t.Name).ToList()));

        private static List<ObservableToDoItem> ConvertToDoItemsToObservable(List<ToDoItem> items)
        {
            List<ObservableToDoItem> collection = new();
            foreach (ToDoItem item in items)     //TODO: Is there a better way to do this? This isn't very performant...
            {
                ObservableToDoItem observableItem = new(item);
                collection.Add(observableItem);
            }
            return collection;
        }

        [RelayCommand]
        private void Add()
        {
            this.IsAdding = true;   //TODO: Disable selection for the collectionview when IsAdding == true;

            ObservableToDoItem itemToAdd = new(new ToDoItem { Name = string.Empty });
            this.ToDoItems.Add(itemToAdd);
            this.SelectedToDoItem = itemToAdd;
        }
    }

    public class ObservableToDoItem : ObservableObject
    {
        private readonly ToDoItem _toDoItem;

        public ObservableToDoItem(ToDoItem toDoItem) => this._toDoItem = toDoItem;

        public int Id
        {
            get => this._toDoItem.Id;
            set => this.SetProperty(this._toDoItem.Id, value, this._toDoItem, (u, i) => u.Id = i);
        }

        public string Name
        {
            get => this._toDoItem.Name;
            set => this.SetProperty(this._toDoItem.Name, value, this._toDoItem, (u, n) => u.Name = n);
        }

        public string? Description
        {
            get => this._toDoItem.Description;
            set => this.SetProperty(this._toDoItem.Description, value, this._toDoItem, (u, d) => u.Description = d);
        }

        public bool IsImportant
        {
            get => this._toDoItem.IsImportant;
            set => this.SetProperty(this._toDoItem.IsImportant, value, this._toDoItem, (u, i) => u.IsImportant = i);
        }

        public bool IsComplete
        {
            get => this._toDoItem.IsComplete;
            set => this.SetProperty(this._toDoItem.IsComplete, value, this._toDoItem, (u, i) => u.IsComplete = i);
        }

        public DateTime? DueDate
        {
            get => this._toDoItem.DueDate;
            set => this.SetProperty(this._toDoItem.DueDate, value, this._toDoItem, (u, d) => u.DueDate = d);
        }
    }
}
