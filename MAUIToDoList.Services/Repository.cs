using MAUIToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIToDoList.Services
{
    public class Repository : IRepository
    {
        private readonly SimpleToDoListContext _context;

        public Repository() => this._context = new();


        public ToDoItem? Get(int id) => this._context.ToDoItems.Find(id) ?? null;

        public IEnumerable<ToDoItem> GetAll() => this._context.ToDoItems;
        
        public ToDoItem Create(ToDoItem itemToCreate)
        {
            try
            {
                if (itemToCreate == null) { throw new ArgumentException("The item to create doesn't exist.", nameof(itemToCreate)); }
                if (itemToCreate.Id != 0) { throw new ArgumentException("The item to create cannot have an Id that isn't zero.", nameof(itemToCreate.Id)); }
                
                this._context.ToDoItems.Add(itemToCreate);
                this._context.SaveChanges();
            }
            catch (Exception) { throw; }
            return itemToCreate;
        }
        public ToDoItem Update(ToDoItem itemToUpdate)
        {
            try
            {
                if (itemToUpdate == null) { throw new ArgumentException("The item to update doesn't exist.", nameof(itemToUpdate)); }
                if (itemToUpdate.Id == 0) { throw new ArgumentException("The item to update cannot have an Id that is zero.", nameof(itemToUpdate)); }

                this._context.ToDoItems.Update(itemToUpdate);
                this._context.SaveChanges();
            }
            catch (Exception) { throw; }
            return itemToUpdate;
        }
        public bool Delete(int id)
        {
            try
            {
                if (id <= 0) { throw new ArgumentException("The item to delete cannot have an Id that is less than or equal to zero.", nameof(id)); }

                ToDoItem? found = this.Get(id);

                if (found == null) { throw new Exception("The item to delete doesn't exist."); }

                this._context.ToDoItems.Remove(found);
                this._context.SaveChanges();
            }
            catch (Exception) { throw; }
            return true;
        }
    }
}
