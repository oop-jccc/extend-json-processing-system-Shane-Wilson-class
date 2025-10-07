[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=20932102)
![UML Diagram](uml.png)

### Instructions

1. **Create a `TodoItem` Record:**
   - Navigate to the `Models` folder and create a new file named `TodoItem.cs`.
   - Define a `public` record named `TodoItem` with the following read-only properties (using the `init` accessor):
     - `string Title`
     - `bool IsCompleted`

2. **Create a `TodoItemProcessor` Class:**
   - Navigate to the `JsonProcessors` folder and create a new file named `TodoItemProcessor.cs`.
   - Define a `public` class named `TodoItemProcessor` that implements the `IJsonProcessor` interface.
   - Implement the `CanProcess` method to check if the provided `JObject` contains the necessary keys for a `TodoItem`.
   - Implement the `Process` method to deserialize the `JObject` to a `TodoItem` object. Utilize the `with` operator to create a safe, non-destructive copy of the `TodoItem` with the `IsCompleted` property set to `true`.

3. **Update Dependency Injection:**
   - Navigate to the `Program` class.
   - In the `Main` method, locate the section where dependency injection is set up.
   - Add a new line to register the `TodoItemProcessor` class with the dependency injection collection.

### Running the Application

1. Run the application. The Swagger UI will pop up.
2. To test the `TodoItemProcessor`, use the following JSON string in the Swagger UI:
   ```json
   "{\"Title\":\"Buy Milk\",\"IsCompleted\":false}"
   ```
   This will simulate processing a Todo item and should return a Todo item with `IsCompleted` set to `true`.

### Important Notes

- Your implementation should adhere to the Open/Closed Principle; no existing code should be modified except for the dependency injection setup in the `Program` class.
- This design follows the Strategy Design Pattern by enabling the program to use different processors interchangeably through the `IJsonProcessor` interface.
- Ensure your code is clean, and follows the coding standards discussed in class. The `TodoItem` record's properties should remain read-only, demonstrating the safe handling of data by utilizing the `with` operator in the `TodoItemProcessor` class.

## Technologies Used

- ASP.NET Core 6.0
- Newtonsoft.Json
- Swagger/OpenAPI
- C# Records and Pattern Matching

## Learning Objectives

- Strategy Design Pattern implementation
- SOLID principles (especially Open/Closed)
- Dependency Injection in .NET
- Immutable data structures with C# records
- Web API development with ASP.NET Core