using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Delegates.Experiences;
using amBXLib.Net.Device;
using amBXLib.Net.Device.Experiences;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Factories
{
  class EventFactory : IExperienceFactory<Event>
  {
    private readonly amBXDeviceManager deviceManager;

    public EventFactory(amBXDeviceManager deviceManager)
    {
      this.deviceManager = deviceManager;
    }

    public Event Create(string name, byte[] fileContents)
    {
      var eventPtr = CreateEvent(fileContents);
      var eventInterface = Marshal.PtrToStructure<EventInterface>(eventPtr);
      var eventDelegates = new EventDelegates(eventInterface);

      return new Event(name, eventPtr, eventDelegates);
    }

    private IntPtr CreateEvent(byte[] content)
    {
      deviceManager.CheckConnection();
      var r = new IntPtr();
      ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateEvent(deviceManager.DevicePtr, content, content.Length, ref r));
      return r;
    }
  }
}
