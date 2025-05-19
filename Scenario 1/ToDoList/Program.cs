// Copyright (C) Microsoft Corporation. All rights reserved.

using System.Threading.Tasks;

namespace ToDoList
{
    public static class Program
    {
        [global::System.STAThreadAttribute]
        static async Task Main(string[] args)
        {
            global::WinRT.ComWrappersSupport.InitializeComWrappers();

            await using (global::Shmuelie.WinRTServer.ComServer server = new())
            {
                server.RegisterActions();
                server.Start();

                global::Microsoft.UI.Xaml.Application.Start((p) =>
                {
                    var context = new global::Microsoft.UI.Dispatching.DispatcherQueueSynchronizationContext(global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread());
                    global::System.Threading.SynchronizationContext.SetSynchronizationContext(context);
                    new App();
                });
            }
        }
    }
}