//Accessing Data
builder.Services.AddSingleton<TodoListPage>();
builder.Services.AddTransient<TodoItemPage>();

builder.Services.AddSingleton<TodoItemDatabase>();

TodoItemDatabase database;

public TodoItemPage(TodoItemDatabase todoItemDatabase)
{
    InitializeComponent();
    database = todoItemDatabase;
}

async void OnSaveClicked(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(Item.Name))
    {
        await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
        return;
    }

    await database.SaveItemAsync(Item);
    await Shell.Current.GoToAsync("..");
}