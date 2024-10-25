using Task3.Entities;

namespace Task3.Repository.Todo;

/// <summary>
/// ToDoModelに対するCRUD処理を提供するインターフェース
/// </summary>
public interface IToDoRepository
{
    /// <summary>
    /// ToDoModelのリストを取得する
    /// </summary>
    /// <returns>ToDoModelのリスト</returns>
    Task<List<ToDoModel>> GetToDoListAsync();

    /// <summary>
    /// ToDoModelを追加する
    /// </summary>
    /// <param name="todo">追加するToDoModel</param>
    /// <returns>追加したToDoModel</returns>
    Task<ToDoModel> AddToDoAsync(ToDoModel todo);

    /// <summary>
    /// ToDoModelを更新する
    /// </summary>
    /// <param name="todo">更新するToDoModel</param>
    /// <returns>更新したToDoModel</returns>
    Task<ToDoModel> UpdateToDoAsync(ToDoModel todo);

    /// <summary>
    /// ToDoModelを削除する
    /// </summary>
    /// <param name="todo">削除するToDoModel</param>
    /// <returns>削除したToDoModel</returns>
    Task<ToDoModel> DeleteToDoAsync(ToDoModel todo);
}
