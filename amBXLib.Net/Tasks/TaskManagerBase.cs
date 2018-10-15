using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interop;

namespace amBXLib.Net.Tasks
{
    public abstract class TaskManagerBase
    {
      protected readonly amBXDeviceManager deviceManager;
      protected Task task;
      private CancellationTokenSource taskCanceller;

      protected TaskManagerBase(amBXDeviceManager deviceManager)
      {
        this.deviceManager = deviceManager;
      }

      public void Start()
      {
        task.Start();
      }

    public bool TaskIsRunning()
      {
        return task != null && !task.IsCompleted;
      }
    
      public abstract void Stop();
    }
}
