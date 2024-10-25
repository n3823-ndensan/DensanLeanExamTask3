using Microsoft.AspNetCore.Components;
using Task3.Entities;

namespace Task3.Components.Pages;

public partial class TodoForm
{
    [Inject]
    private NavigationManager Navigation { get; set; }

    [Parameter]
    public string? Id { get; set; }

    private ToDoModel todo = new ToDoModel();

    private bool IsInsert = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (!string.IsNullOrEmpty(Id))
            {
                todo = await ToDoRepository.GetToDoListByIdAsync(Id);
                IsInsert= false;
            }
            else
            {
                // 新規作成の場合の処理
                todo = new ToDoModel();
                IsInsert = true;
            }
        }
        catch (Exception ex)
        {
            // 例外処理
            Console.Error.WriteLine($"Error initializing component: {ex.Message}");
            // 必要に応じてユーザーにエラーメッセージを表示する処理を追加
        }
    }

    private void HandleValidSubmit()
    {
        if (IsInsert)
        {
            ToDoRepository.AddToDoAsync(todo);
        }
        else
        {
            ToDoRepository.UpdateToDoAsync(todo);
        }

        NavigateToHome();
    }
    private void NavigateToHome()
    {
        Navigation.NavigateTo("/");
    }
}
