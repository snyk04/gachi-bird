using System.Threading.Tasks;

namespace AreYouFruits.Common
{
    public static class Tasks
    {
        public static async Task DelaySeconds(float seconds)
        {
            await Task.Delay((int) (seconds * 1000));
        }
    }
}