using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Delegates.Components
{
  public abstract class ComponentDelegates : EntityDelegates
  {
    public GetLocationDelegate GetLocation;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetLocationDelegate(IntPtr rumblePtr, ref ComponentDirection direction);
  }
}
