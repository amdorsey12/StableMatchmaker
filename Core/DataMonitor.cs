using System.Threading.Tasks;

namespace Dorsey.StableMatchmaker
{
    public class DataMonitor : IDataMonitor
    {
        public bool IsRunning { get; set; }

        public async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(500);
            }
        }
    }
}