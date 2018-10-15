using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  [StructLayout(LayoutKind.Sequential)]
  public struct FanInterface
  {
    public IntPtr ReleasePtr;
    public IntPtr SetIntensityPtr;
    public IntPtr GetIntensityPtr;
    public IntPtr GetLocationPtr;
    public IntPtr GetEnabledPtr;
    public IntPtr SetEnabledPtr;
    public IntPtr SetUpdatePropertiesPtr;
    public IntPtr GetUpdatePropertiesPtr;
  }
}
