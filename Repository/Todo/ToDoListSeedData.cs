using Task3.Entities;

namespace Task3.Repository.Todo;

public class ToDoListSeedData
{
    public static void Initialize(IToDoRepository repository)
    {
        var todoList = new List<ToDoModel>
        {
            new ToDoModel
            {
                Title = "Task3",
                Deadline = new DateTime(2024, 12, 13),
                Status = 2,
                Content = "Task3 Content"
            },
            new ToDoModel
            { 
                Title = "Task1",
                Deadline = new DateTime(2024,12,12), 
                Status = 0, 
                Content = "Task1 Content"
            },
            new ToDoModel
            { 
                Title = "Task2", 
                Deadline = new DateTime(2024, 12, 11), 
                Status = 0, 
                Content = "Task2 Content"
            }
        };

        foreach (var todo in todoList)
        {
            repository.AddToDoAsync(todo);
        }
    }
}
