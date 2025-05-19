// Copyright (C) Microsoft Corporation. All rights reserved.

using System.Threading.Tasks;
using Microsoft.AI.Actions.Annotations;

namespace ToDoList
{
    [ActionProvider]
    public sealed class ToDoActionHandler
    {
        [WindowsAction(Description = "Add item to your to-do list", Icon = "ms-resource://Files/Assets/LockScreenLogo.png", UsesGenerativeAI = false)]
        [WindowsActionInputCombination(Inputs = ["todo"], Description = "Add '${todo.ShortText}' to your to-do list.")]
        public async Task<AddToListResult> AddToList(string todo)
        {
            await App.EnsureAppIsInitialized();

            string result = "Unknown";
            if (App.Current is App { m_window: MainWindow mainWindow })
            {
                result = await mainWindow.AddToDoListItemAsync(todo);
            }

            return new AddToListResult
            {
                Response = result
            };
        }
    }

    public record AddToListResult
    {
        public required string Response { get; init; }
    }
}
