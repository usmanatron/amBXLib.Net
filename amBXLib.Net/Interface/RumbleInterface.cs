using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  /// <remarks>
  /// The order MUST NOT BE CHANGED; it needs to match that in the C class.
  /// </remarks>
  [StructLayout(LayoutKind.Sequential)]
  public struct RumbleInterface
  {
    public IntPtr ReleasePtr;
    public IntPtr SetRumblePtr;
    public IntPtr GetRumblePtr;
    public IntPtr GetLocationPtr;
    public IntPtr GetEnabledPtr;
    public IntPtr SetEnabledPtr;
    public IntPtr SetUpdatePropertiesPtr;
    public IntPtr GetUpdatePropertiesPtr;
  }
}
