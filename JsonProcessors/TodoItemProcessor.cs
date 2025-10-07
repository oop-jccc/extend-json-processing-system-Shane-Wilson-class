using dynamic_json.JsonProcessors;
using Newtonsoft.Json.Linq;


namespace dynamic_json.Models;

public class TodoItemProcessor : IJsonProcessor
{
    public bool CanProcess(JObject json)
    {
        return json.ContainsKey("Title") && json.ContainsKey("IsCompleted");
    }

    public object? Process(JObject json)
    {
        if (!CanProcess(json)) return null;

        var todoItem = json.ToObject<TodoItem>();
        if (todoItem is null) return null;

        // Create a safe, non-destructive copy with IsCompleted set to true
        var completedTodo = todoItem with { IsCompleted = true };
        return completedTodo;
    }
}