using Task3.Entities;

namespace Task3.Repository.Todo;

/// <summary>
/// IToDoRepositoryのインメモリ実装クラス
/// </summary>
public class ToDoInMemoryRepository : IToDoRepository
{
    private readonly List<ToDoModel> _todoList = new List<ToDoModel>();

    public ToDoInMemoryRepository()
    {
        ToDoListSeedData.Initialize(this);
    }
    public Task<ToDoModel> GetToDoListByIdAsync(string Id)
    {
        return Task.FromResult(GetToDoListById(Id).Clone());
    }

    /// <summary>
    /// ToDoModelのリストを取得する
    /// </summary>
    /// <returns>ToDoModelのリスト</returns>
    public Task<List<ToDoModel>> GetToDoListAsync()
    {
        //_todoListのCloneリストを返却する
        return Task.FromResult(_todoList.Select(x => x.Clone()).ToList());
    }

    /// <summary>
    /// ToDoModelを追加する
    /// </summary>
    /// <param name="todo">追加するToDoModel</param>
    /// <returns>追加したToDoModel</returns>
    public Task<ToDoModel> AddToDoAsync(ToDoModel todo)
    {
        _todoList.Add(todo);
        return Task.FromResult(todo);
    }

    /// <summary>
    /// ToDoModelを更新する
    /// </summary>
    /// <param name="todo">更新するToDoModel</param>
    /// <returns>更新したToDoModel</returns>
    public Task<ToDoModel> UpdateToDoAsync(ToDoModel todo)
    {
        var target = GetToDoListById(todo.Id);
        //todoをtargetにコピー
        target.Title = todo.Title;
        target.Deadline = todo.Deadline;
        target.Status = todo.Status;
        target.Content = todo.Content;
        return Task.FromResult(target);
    }

    /// <summary>
    /// ToDoModelを削除する
    /// </summary>
    /// <param name="todo">削除するToDoModel</param>
    /// <returns>削除したToDoModel</returns>
    public Task<ToDoModel> DeleteToDoAsync(ToDoModel todo)
    {
        var target = GetToDoListById(todo.Id);
        _todoList.Remove(target);
        return Task.FromResult(target);
    }

    private ToDoModel GetToDoListById(string Id)
    {
        ToDoModel? todo = _todoList.Find(x => x.Id == Id);
        if (todo == null)
        {
            throw new KeyNotFoundException($"ToDoModel not found. Id: {Id}");
        }
        return todo;
    }

}
