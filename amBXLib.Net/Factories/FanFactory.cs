using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Delegates.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;
using amBXLib.Net.Device;
using amBXLib.Net.Device.Components;

namespace amBXLib.Net.Factories
{
  public class FanFactory : IComponentFactory<Fan>
    {
      private readonly amBXDeviceManager deviceManager;

      public FanFactory(amBXDeviceManager deviceManager)
      {
        this.deviceManager = deviceManager;
      }

      public Fan Create(string name, ComponentDirection direction, ComponentHeight componentHeight)
      {
        var fanPtr = CreateFan(direction, componentHeight);
        var fanInterface = Marshal.PtrToStructure<FanInterface>(fanPtr);
        var fanDelegates = new FanDelegates(fanInterface);

        return new Fan(name, fanPtr, fanDelegates);
      }

      private IntPtr CreateFan(ComponentDirection componentDirection, ComponentHeight componentHeight)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateFan(deviceManager.DevicePtr, componentDirection, componentHeight, ref r));
        return r;
      }
  }
}
