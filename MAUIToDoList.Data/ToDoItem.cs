namespace MAUIToDoList.Data;

public partial class ToDoItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsImportant { get; set; }

    public bool IsComplete { get; set; }

    public DateTime? DueDate { get; set; }
}
