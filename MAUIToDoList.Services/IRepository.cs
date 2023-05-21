using MAUIToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIToDoList.Services
{
    public interface IRepository
    {
        ToDoItem? Get(int id);
        IEnumerable<ToDoItem> GetAll();
        ToDoItem Create(ToDoItem itemToCreate);
        ToDoItem Update(ToDoItem itemToUpdate);
        bool Delete(int id);
    }
}
