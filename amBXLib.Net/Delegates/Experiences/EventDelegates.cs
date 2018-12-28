using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates.Experiences
{
  public class EventDelegates : EntityDelegates
  {
    public readonly PlayDelegate Play;
    public readonly StopDelegate Stop;

    public EventDelegates(EventInterface evtinterface)
    {
      Play = Marshal.GetDelegateForFunctionPointer<PlayDelegate>(evtinterface.PlayPtr);
      Stop = Marshal.GetDelegateForFunctionPointer<StopDelegate>(evtinterface.StopPtr);
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(evtinterface.ReleasePtr);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult PlayDelegate(IntPtr eventPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult StopDelegate(IntPtr eventPttr);
  }
}
