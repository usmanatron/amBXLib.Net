using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Delegates;
using amBXLib.Net.Device.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;
using amBXLib.Net.Device;

namespace amBXLib.Net.Factories
{
  public class RumbleFactory : IFactory<Rumble>
    {
      private readonly amBXDeviceManager deviceManager;

      public RumbleFactory(amBXDeviceManager deviceManager)
      {
        this.deviceManager = deviceManager;

      }

      public Rumble Create(string name, ComponentDirection direction, ComponentHeight componentHeight)
      {
        var rumblePtr = CreateRumble(direction, componentHeight);
        var rumbleInterface = Marshal.PtrToStructure<RumbleInterface>(rumblePtr);
        var rumbleDelegates = new RumbleDelegates(rumbleInterface);

        return new Rumble(name, rumblePtr, rumbleDelegates);
      }

      private IntPtr CreateRumble(ComponentDirection componentDirection, ComponentHeight componentHeight)
      {
        deviceManager.CheckConnection();
        var r = new IntPtr();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateRumble(deviceManager.DevicePtr, componentDirection, componentHeight, ref r));
        return r;
      }
  }
}