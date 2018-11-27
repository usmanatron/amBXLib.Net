using System;
using amBXLib.Net.Factories;
using amBXLib.Net.Device;
using amBXLib.Net.Device.Components;
using amBXLib.Net.Tasks;

namespace amBXLib.Net
{
    public class amBXBuilder
    {
      private readonly amBXDeviceManager deviceManager;
      private readonly IComponentFactory<Light> lightFactory;
      private readonly IComponentFactory<Fan> fanFactory;
      private readonly IComponentFactory<Rumble> rumbleFactory;
      private readonly AsyncUpdateManager asyncUpdate;
      private readonly amBX amBX;

      private int updatesPerSecond;
      private bool asyncUpdateEnabled;

      public amBXBuilder(amBXDeviceManager deviceManager, IComponentFactory<Light> lightFactory, IComponentFactory<Fan> fanFactory, IComponentFactory<Rumble> rumbleFactory, MainTaskManager mainTask, AsyncUpdateManager asyncUpdate)
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
        asyncUpdateEnabled = useThreads;
        deviceManager.Connect(majorVersion, minorVersion, applicationName, applicationVersion, asyncUpdateEnabled);
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
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateEvent(deviceManager.DevicePtr, file, file.Length, ref r));
        return r;
      }

      private IntPtr CreateMovie(byte[] file)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateMovie(deviceManager.DevicePtr, file, file.Length, ref r));
        return r;
      }*/

      public amBXBuilder WithRefreshRate(int updatesPerSecond)
      {
        this.updatesPerSecond = updatesPerSecond;
        return this;
      }

      public amBX Build()
      {
        if (asyncUpdateEnabled)
        {
          asyncUpdate.Start();
        }

        //TODO: Setting UPS has the side-effect of starting the main amBX Thread
        amBX.UpdatesPerSecond = updatesPerSecond;
        return amBX;
      }
    }
}
