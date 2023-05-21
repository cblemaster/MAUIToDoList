using MAUIToDoList.Data;
using MAUIToDoList.Services;
using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IRepository _db;
        public MainPage(IRepository repository)
        {
            this.InitializeComponent();

            this._db = repository;

            this.BindingContext = this;
        }

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }



    }
}