using Task3.Entities;

namespace Task3.Services;


public class HomeState
{
    public bool IsLoading { get; set; } = true;

    public List<ToDoModel> ToDoList { get; set; } = new List<ToDoModel>();
}
