
//Initilization 
public class TodoItemDatabase
{
    SQLiteAsyncConnection Database;

    public TodoItemDatabase()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<TodoItem>();
    }
    ...
}