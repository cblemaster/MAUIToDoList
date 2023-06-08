﻿using System.Collections.ObjectModel;

namespace MAUIToDoList.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this._context = ((MainPageModel)this.BindingContext);

            this._context.IsAdding = false;
            this._context.IsEditing = false;
        }

        private readonly MainPageModel _context;

        private void filter_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this._context.FilteredToDoItems = e.Value
                ? this._context.ToDoItems
                : new ObservableCollection<ObservableToDoItem>(this._context.ToDoItems.Where(t => !t.IsComplete));
            this.list.SelectedItem = null;
        }

        private void detailControl_ValueChanged(object sender, EventArgs e) =>
            this.SetIsEditing(isEditing: true);

        private void SetIsEditing(bool isEditing = true) =>
            this._context.IsEditing = isEditing;
    }
}