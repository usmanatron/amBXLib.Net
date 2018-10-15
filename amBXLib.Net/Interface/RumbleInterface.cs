using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
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
