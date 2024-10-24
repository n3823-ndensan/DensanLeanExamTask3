using System.Collections.Generic;
using Task3.Entities;

namespace Task3.Components.Pages;

public partial class Home
{
    private List<ToDoModel> ToDoList = new List<ToDoModel>();

    protected override async Task OnInitializedAsync()
    {
        await LoadTodoList();
        StateHasChanged();
    }
    public async Task LoadTodoList()
    {
        await InitTodoList();
        StateHasChanged();
    }

    private async Task InitTodoList()
    {
        Console.WriteLine("TodoList読み込み開始");
        await Task.Delay(3000);
        ToDoList.Add(
            new ToDoModel
            { Title = "Task1", Deadline = DateTime.Now, Status = 0, Content = "Task1 Content"
            }
        );
        ToDoList.Add(
            new ToDoModel
            { Title = "Task2", Deadline = DateTime.Now, Status = 1, Content = "Task2 Content"
            }
        );
        ToDoList.Add(
            new ToDoModel
            { Title = "Task3", Deadline = DateTime.Now, Status = 2, Content = "Task3 Content"
            }
        );
        Console.WriteLine("TodoList読み込み終了");
    }

}