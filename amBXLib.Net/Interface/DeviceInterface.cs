using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  /// <summary>
  /// Matches the structure of the C amBX class as
  /// an array of function pointers.
  /// </summary>
  /// <remarks>
  /// The order MUST NOT BE CHANGED; it needs to match that in the C class.
  /// </remarks>
  [StructLayout(LayoutKind.Sequential)]
  public struct DeviceInterface
  {
    public IntPtr ReleasePtr;
    public IntPtr CreateLightPtr;
    public IntPtr CreateFanPtr;
    public IntPtr CreateRumblePtr;
    public IntPtr CreateMoviePtr;
    public IntPtr CreateEventPtr;
    public IntPtr SetAllEnabledPtr;
    public IntPtr UpdatePtr;
    public IntPtr GetVersionInfoPtr;
    public IntPtr RunThreadPtr;
    public IntPtr StopThreadPtr;

  }
}
