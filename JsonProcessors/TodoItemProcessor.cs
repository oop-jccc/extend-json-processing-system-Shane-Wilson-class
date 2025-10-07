using dynamic_json.JsonProcessors;
using Newtonsoft.Json.Linq;


namespace dynamic_json.Models;

public class TodoItemProcessor : IJsonProcessor
{
    public bool CanProcess(JObject json)
    {
        return json.ContainsKey(nameof(TodoItem.Title)) &&
               json.ContainsKey(nameof(TodoItem.IsCompleted));
    }

    public object? Process(JObject json)
    {
        if (!CanProcess(json)) return null;

        var todoItem = json.ToObject<TodoItem>();
        return todoItem! with
        {
            IsCompleted = true
        };
    }
}