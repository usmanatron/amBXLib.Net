using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  /// <remarks>
  /// The order MUST NOT BE CHANGED; it needs to match that in the C class.
  /// </remarks>
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
