using System;
using System.Threading;
using System.Threading.Tasks;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interop;

namespace amBXLib.Net.Tasks
{
  public class MainTaskManager : TaskManagerBase
  {
    private int updatesPerSecond;
    private CancellationTokenSource taskCanceller;

    public MainTaskManager(amBXDeviceManager deviceManager) : base(deviceManager)
    {
      task = new Task(Run, taskCanceller.Token);
    }

    public void SetRefreshRate(int updatesPerSecond)
    {
      this.updatesPerSecond = updatesPerSecond;
    }
    
    private void Run()
    {
      deviceManager.CheckConnection();
      try
      {
        do
        {
          if (updatesPerSecond > 0)
          {
            var start = DateTime.Now;
            deviceManager.CheckConnection();
            ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.Update(deviceManager.amBXPtr, 0));
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
