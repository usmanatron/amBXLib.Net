using System;
using System.Threading;
using System.Threading.Tasks;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Device;

namespace amBXLib.Net.Tasks
{
  public class MainTaskManager : TaskManagerBase
  {
    private int updatesPerSecond;
    private readonly CancellationTokenSource taskCanceller;

    public MainTaskManager(amBXDeviceManager deviceManager) : base(deviceManager)
    {
      taskCanceller = new CancellationTokenSource();
      Task = new Task(Run, taskCanceller.Token);
    }

    public void SetRefreshRate(int updatesPerSecond)
    {
      this.updatesPerSecond = updatesPerSecond;
    }
    
    private void Run()
    {
      DeviceManager.CheckConnection();
      try
      {
        do
        {
          if (updatesPerSecond > 0)
          {
            var start = DateTime.Now;
            DeviceManager.CheckConnection();
            ExceptionHelper.CheckForException(DeviceManager.DeviceDelegates.Update(DeviceManager.DevicePtr, 0));
            var duration = DateTime.Now - start;
            Thread.Sleep(Math.Max(0, (1000 / updatesPerSecond) - duration.Milliseconds));
          }
          else
          {
            break;
          }
        } while (true);

      }
      catch (ThreadAbortException)
      {
        // Allow
      }
    }

    public override void Stop()
    {
      taskCanceller.Cancel();
    }
  }
}
