using System;
using System.Runtime.InteropServices;

namespace amBXLib.Net.Interface
{
  [StructLayout(LayoutKind.Sequential)]
  public struct LightInterface
  {
    public IntPtr ReleasePtr;
    public IntPtr SetColPtr;
    public IntPtr GetColPtr;
    public IntPtr SetFadeTimePtr;
    public IntPtr GetFadeTimePtr;
    public IntPtr GetLocationPtr;
    public IntPtr SetEnabledPtr;
    public IntPtr GetEnabledPtr;
    public IntPtr SetUpdatePropertiesPtr;
    public IntPtr GetUpdatePropertiesPtr;
  }
}