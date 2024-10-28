using Microsoft.AspNetCore.Components;
using Task3.Entities;
using Task3.Services;

namespace Task3.Components.Pages;

public partial class Home
{
    private HomeState? State { get; set; }

    private void NavigateToAddTodoPage() => NavigationManager.NavigateTo("/todo/form");

    protected override async Task OnInitializedAsync()
    {
        State = new HomeState(ToDoRepository);
        State.IsLoading = true;
        await State.LoadTodoList();
        State.IsLoading = false;
        StateHasChanged();
    }

    private void OnUpdateRow(ToDoModel todo)
    {
        NavigationManager.NavigateTo($"/todo/form/{todo.Id}");
    }
}