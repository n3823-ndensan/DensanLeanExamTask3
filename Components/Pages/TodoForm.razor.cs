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
        // 実行完了時の処理をここに追加します
        Console.WriteLine("フォームが正常に送信されました。");
        // 例えば、リダイレクトやメッセージの表示など
        Navigation.NavigateTo("/home");
    }

}
