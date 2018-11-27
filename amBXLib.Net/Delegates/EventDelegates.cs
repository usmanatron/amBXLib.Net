using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  //qqUMI Use this to commonise the entity requirement of this onto amBXEntity
  interface IEntityDelegates
  {

  }

  public class EventDelegates : IEntityDelegates
  {
    public readonly PlayDelegate Play;
    public readonly StopDelegate Stop;
    public readonly ReleaseDelegate Release;

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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult ReleaseDelegate(IntPtr eventPtr);
  }
}
