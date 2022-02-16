using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreYouFruits.Common
{
    public static class VoidTasks
    {
        public static async void Repeat(this Action action, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                action();
                
                await Task.Yield();
            }
        }
    }
}
