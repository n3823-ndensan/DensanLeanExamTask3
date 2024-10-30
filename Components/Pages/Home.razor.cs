using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Task3.Entities;
using Task3.Repository.Todo;
using Task3.Services;

namespace Task3.Components.Pages;

public partial class Home
{
    private HomeState? State { get; set; }

    private void NavigateToAddTodoPage() => NavigationManager.NavigateTo("/todo/form");

    //dataGridのリロードを行うために参照を保持
    private RadzenDataGrid<ToDoModel>? dataGrid;

    protected override async Task OnInitializedAsync()
    {
        State = new HomeState();
        State.IsLoading = true;
        await LoadTodoList();
        State.IsLoading = false;
        StateHasChanged();
    }

    private void OnUpdateRow(ToDoModel todo)
    {
        NavigationManager.NavigateTo($"/todo/form/{todo.Id}");
    }
    private async Task OnDeleteRow(ToDoModel todo)
    {
        if (dataGrid is null || State is null) return;
        State.IsLoading = true;

        await ToDoRepository.DeleteToDoAsync(todo);
        await LoadTodoList();
        await dataGrid.Reload();
        
        State.IsLoading = false;
    }
    public async Task LoadTodoList()
    {
        //StateがNullの場合は何もしない
        if (State is null) return;

        //テストのために意図的に3秒待機
        await Task.Delay(3000);

        State.ToDoList = await ToDoRepository.GetToDoListAsync();
        State.ToDoList.Sort((x, y) => x.CompareTo(y));
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