using System.Threading.Tasks;
using amBXLib.Net.Device;

namespace amBXLib.Net.Tasks
{
  public abstract class TaskManagerBase
  {
    protected readonly amBXDeviceManager DeviceManager;
    protected Task Task;

    protected TaskManagerBase(amBXDeviceManager deviceManager)
    {
      DeviceManager = deviceManager;
    }

    public void Start()
    {
      Task.Start();
    }

    public bool TaskIsRunning()
    {
      return Task != null && !Task.IsCompleted;
    }

    public abstract void Stop();
  }
}
