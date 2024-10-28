using Microsoft.AspNetCore.Components;
using Task3.Repository.Todo;
using Task3.Entities;

namespace Task3.Services;


public class HomeState
{
    private IToDoRepository toDoRepository { get; }

    public HomeState(IToDoRepository toDoRepository)
    {
        //nullチェックと設定
        this.toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
    }

    public bool IsLoading { get; set; } = true;

    public List<ToDoModel> ToDoList { get; set; } = new List<ToDoModel>();

    public async Task LoadTodoList()
    {
        //テストのために意図的に3秒待機
        await Task.Delay(3000);

        ToDoList = await toDoRepository.GetToDoListAsync();
        ToDoList.Sort((x, y) => x.CompareTo(y));
    }

    public string GetContentFirstLine(string? content)
    {
        if (string.IsNullOrEmpty(content)) return string.Empty;

        var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0) return string.Empty;

        if (lines.Length == 1) return lines.First();

        return $"{lines.First()} ...";

    }

    public string GetStatusName(int no)
    {
        return ToDoModel.Statuses.FirstOrDefault(s => s.No == no).Name;
    }
}
