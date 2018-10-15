using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  [StructLayout(LayoutKind.Sequential)]
  struct MovieInterface
  {

    public IntPtr ReleasePtr;
    public IntPtr SetFrozenPtr;
    public IntPtr GetFrozenPtr;
    public IntPtr SetSuspendedPtr;
    public IntPtr GetSuspendedPtr;
    public IntPtr SeekPtr;
  }
}
