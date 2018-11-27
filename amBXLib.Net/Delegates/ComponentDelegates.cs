using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Delegates
{
    public abstract class ComponentDelegates
    {
      public ReleaseDelegate Release;
      public GetLocationDelegate GetLocation;

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate amBXOperationResult ReleaseDelegate(IntPtr rumblePtr);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate amBXOperationResult GetLocationDelegate(IntPtr rumblePtr, ref ComponentDirection direction);
  }
}
