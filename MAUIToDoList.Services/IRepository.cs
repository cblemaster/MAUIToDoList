using MAUIToDoList.Data;

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
