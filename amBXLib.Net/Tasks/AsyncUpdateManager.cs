using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interop;

namespace amBXLib.Net.Tasks
{
  public class AsyncUpdateManager : TaskManagerBase
  {
    public AsyncUpdateManager(amBXDeviceManager deviceManager) : base(deviceManager)
    {
      task = new Task(Run);
    }

    private void Run()
    {
      deviceManager.CheckConnection();
      ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.RunThread(deviceManager.amBXPtr, amBX_ThreadType.amBX_Ambient_Update, task.Id));
    }

    public override void Stop()
    {
      deviceManager.CheckConnection();
      ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.StopThread(deviceManager.amBXPtr, task.Id));
    }
  }
}
