using System;
using System.Threading;
using amBXLib.Net.Factories;
using amBXLib.Net.Interop;
using amBXLib.Net.Tasks;

namespace amBXLib.Net
{
    public class amBXBuilder
    {
      private readonly amBXDeviceManager deviceManager;
      private readonly LightFactory lightFactory;
      private readonly FanFactory fanFactory;
      private readonly RumbleFactory rumbleFactory;
      private readonly AsyncUpdateManager asyncUpdate;
      private readonly amBX amBX;

      private int updatesPerSecond;
      private bool useThreads;

      public amBXBuilder(amBXDeviceManager deviceManager, LightFactory lightFactory, FanFactory fanFactory, RumbleFactory rumbleFactory, MainTaskManager mainTask, AsyncUpdateManager asyncUpdate)
      {
        this.deviceManager = deviceManager;
        this.lightFactory = lightFactory;
        this.fanFactory = fanFactory;
        this.rumbleFactory = rumbleFactory;
        this.asyncUpdate = asyncUpdate;
        amBX = new amBX(deviceManager, mainTask, asyncUpdate);

        updatesPerSecond = 20; // Default value
      }

      /// <summary>
      /// MUST BE CALLED FIRST.
      /// Sets up the connection to the hardware, which is required
      /// by everything else.
      /// </summary>
      public amBXBuilder WithConnection(uint majorVersion, uint minorVersion, string applicationName = "", string applicationVersion = "", bool useThreads = false)
      {



        this.useThreads = useThreads;
        deviceManager.Connect(majorVersion, minorVersion, applicationName, applicationVersion, useThreads);
        return this;
      }

      public amBXBuilder WithLight(ComponentDirection direction, ComponentHeight componentHeight, string name = "")
      {
        var light = lightFactory.Create(name, direction, componentHeight);
        amBX.Lights.Add(light);
        return this;
      }

      public amBXBuilder WithFan(ComponentDirection direction, ComponentHeight componentHeight, string name = "")
      {
        var fan = fanFactory.Create(name, direction, componentHeight);
        amBX.Fans.Add(fan);
        return this;
      }

      public amBXBuilder WithRumble(ComponentDirection direction, ComponentHeight componentHeight, string name = "")
      {
        var rumble = rumbleFactory.Create(name, direction, componentHeight);
        amBX.Rumbles.Add(rumble);
        return this;
      }

      public amBXBuilder WithEvent()
      {
        throw new NotImplementedException();
      }

      public amBXBuilder WithMovie()
      {
        throw new NotImplementedException();
      }

      /* Not yet implemented
      private IntPtr CreateEvent(byte[] file)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateEvent(deviceManager.amBXPtr, file, file.Length, ref r));
        return r;
      }

      private IntPtr CreateMovie(byte[] file)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateMovie(deviceManager.amBXPtr, file, file.Length, ref r));
        return r;
      }*/

      public amBXBuilder WithRefreshRate(int updatesPerSecond)
      {
        this.updatesPerSecond = updatesPerSecond;
        return this;
      }

      public amBX Build()
      {
        if (useThreads)
        {
          asyncUpdate.Start();
        }

        //TODO: Setting UPS has the side-effect of starting the main amBX Thread
        amBX.UpdatesPerSecond = updatesPerSecond;
        return amBX;
      }
    }
}
