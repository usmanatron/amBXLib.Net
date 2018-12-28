using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Delegates.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;
using amBXLib.Net.Device;
using amBXLib.Net.Device.Components;

namespace amBXLib.Net.Factories
{
  public class LightFactory : IComponentFactory<Light>
    {
      private readonly amBXDeviceManager deviceManager;

      public LightFactory(amBXDeviceManager deviceManager)
      {
        this.deviceManager = deviceManager;

      }

      public Light Create(string name, ComponentDirection direction, ComponentHeight componentHeight)
      {
        var lightPtr = CreateLight(direction, componentHeight);
        var lightInterface = Marshal.PtrToStructure<LightInterface>(lightPtr);
        var lightDelegates = new LightDelegates(lightInterface);

        return new Light(name, lightPtr, lightDelegates);
      }

      private IntPtr CreateLight(ComponentDirection componentDirection, ComponentHeight componentHeight)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateLight(deviceManager.DevicePtr, componentDirection, componentHeight, ref r));
        return r;
      }
  }
}