using Microsoft.AspNetCore.Components;
using Task3.Entities;

namespace Task3.Components.Pages;

public partial class TodoForm
{
    [Inject]
    private NavigationManager Navigation { get; set; }

    private ToDoModel todo = new ToDoModel();

    private void HandleValidSubmit()
    {
        ToDoRepository.AddToDoAsync(todo);

        NavigateToHome();
    }
    private void NavigateToHome()
    {
        Navigation.NavigateTo("/");
    }
}
