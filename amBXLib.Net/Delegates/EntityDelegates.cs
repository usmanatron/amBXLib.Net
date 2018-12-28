using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Delegates
{
  public abstract class EntityDelegates
  {
    public ReleaseDelegate Release;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult ReleaseDelegate(IntPtr rumblePtr);
  }
}
