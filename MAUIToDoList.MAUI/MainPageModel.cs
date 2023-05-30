using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIToDoList.Data;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShellItem = Microsoft.Maui.Controls.ShellItem;

namespace MAUIToDoList.MAUI
{
    public class MainPageModel : ObservableObject
    {
        private readonly SimpleToDoListContext _context = new();
        private ObservableCollection<ToDoItem> _toDoItems = new();

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

        public ICommand AddCommand { get; }

        public ObservableCollection<ToDoItem> GetAllToDoItems() => 
            new(this._context.ToDoItems.OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        public ObservableCollection<ToDoItem> GetIncompleteToDoItems() => 
            new(this._context.ToDoItems.Where(t => !t.IsComplete).OrderBy(t => t.DueDate).ThenBy(t => t.Name));

        private async Task Add()
        {
            //await Task.Run(() =>
            //{
                ToDoItem itemToAdd = new() { Name = string.Empty };
                this.ToDoItems.Add(itemToAdd);

                MainPage? page = (MainPage)Shell.Current.CurrentPage;   // HACK: This only works because the main page is the only page...
                if (page != null)
                {
                    CollectionView? list = (CollectionView)page.FindByName("list");
                    if (list != null)
                    {
                        list.SelectedItem = (ToDoItem)itemToAdd;
                    }
                }
            //});
        }

    }
}
