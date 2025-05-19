// Copyright (C) Microsoft Corporation. All rights reserved.

using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace ToDoList
{
    public partial class App : Application
    {
        internal static TaskCompletionSource loaded = new();

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.AppWindow.SetIcon(@"Assets/ToDoListLogo.ico");
            m_window.Activate();

            loaded.SetResult();
        }

        public static async Task EnsureAppIsInitialized()
        {
            if (loaded.Task.IsCompleted)
            {
                return;
            }

            await loaded.Task;
        }

        internal MainWindow? m_window;
    }
}
