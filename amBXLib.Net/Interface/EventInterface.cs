using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  /// <remarks>
  /// The order MUST NOT BE CHANGED; it needs to match that in the C class.
  /// </remarks>
  [StructLayout(LayoutKind.Sequential)]
  public struct EventInterface
  {
    public IntPtr PlayPtr;
    public IntPtr StopPtr;
    public IntPtr ReleasePtr;
  }
}
