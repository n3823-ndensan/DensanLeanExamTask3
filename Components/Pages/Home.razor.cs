using Microsoft.AspNetCore.Components;
using Task3.Entities;

namespace Task3.Components.Pages;

public partial class Home
{

    private void NavigateToAddTodoPage() => NavigationManager.NavigateTo("/todo/form");

    private List<ToDoModel> ToDoList = new List<ToDoModel>();

    protected override async Task OnInitializedAsync()
    {
        await LoadTodoList();
        StateHasChanged();
    }
    public async Task LoadTodoList()
    {
        //テストのために意図的に3秒待機
        await Task.Delay(3000);

        ToDoList = await ToDoRepository.GetToDoListAsync();
        ToDoList.Sort((x, y) => x.CompareTo(y));
        StateHasChanged();
    }
    private string GetContentFirstLine(string? content)
    {
        if (string.IsNullOrEmpty(content)) return string.Empty;

        var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0) return string.Empty;

        if (lines.Length == 1) return lines.First();

        return $"{lines.First()} ...";

    }

    private string GetStatusName(int no)
    {
        return ToDoModel.Statuses.FirstOrDefault(s => s.No == no).Name;
    }

    private void OnUpdateRow(ToDoModel todo)
    {
        NavigationManager.NavigateTo($"/todo/form/{todo.Id}");
    }
}