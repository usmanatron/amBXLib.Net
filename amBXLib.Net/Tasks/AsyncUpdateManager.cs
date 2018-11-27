using System.Threading.Tasks;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Device;

namespace amBXLib.Net.Tasks
{
  public class AsyncUpdateManager : TaskManagerBase
  {
    public AsyncUpdateManager(amBXDeviceManager deviceManager) : base(deviceManager)
    {
      Task = new Task(Run);
    }

    private void Run()
    {
      DeviceManager.CheckConnection();
      ExceptionHelper.CheckForException(DeviceManager.DeviceDelegates.RunThread(DeviceManager.DevicePtr, amBXThreadType.AmbientUpdate, Task.Id));
    }

    public override void Stop()
    {
      DeviceManager.CheckConnection();
      ExceptionHelper.CheckForException(DeviceManager.DeviceDelegates.StopThread(DeviceManager.DevicePtr, Task.Id));
    }
  }
}
