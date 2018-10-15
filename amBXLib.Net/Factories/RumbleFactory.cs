using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;
using amBXLib.Net.Interop;

namespace amBXLib.Net.Factories
{
  public class RumbleFactory
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
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateRumble(deviceManager.amBXPtr, componentDirection, componentHeight, ref r));
        return r;
      }
  }
}