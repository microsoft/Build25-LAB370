// Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.ApplicationModel;

namespace ToDoList
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsChecked { get; set; }
    }

    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<TodoItem> ToDoList { get; } = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();

            TitleBarTextBlock.Text = AppInfo.Current.DisplayInfo.DisplayName;
            ExtendsContentIntoTitleBar = true;
        }

        public async Task<string> AddToDoListItemAsync(string item)
        {
            TaskCompletionSource<string> tcs = new();
            DispatcherQueue.TryEnqueue(() =>
            {
                if (EmptyListMessage.Visibility == Visibility.Visible)
                {
                    EmptyListMessage.Visibility = Visibility.Collapsed;
                }

                ToDoList.Add(new TodoItem { Title = $"Item {ToDoList.Count + 1}: {item}", IsChecked = false });

                tcs.SetResult($"'{item}' was added to your to-do list.");
            });

            return await tcs.Task;
        }
    }
}
