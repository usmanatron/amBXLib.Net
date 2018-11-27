using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Delegates;

namespace amBXLib.Net.Device
{
  /// <summary>
  /// Wraps the amBX device interface and its pointer for
  /// ease of usage elsewhere
  /// </summary>
  public class amBXDeviceManager
  {
    public IntPtr DevicePtr { get; private set; }
    public DeviceDelegates DeviceDelegates { get; private set; }

    /// <summary>
    /// Actually creates the amBX interface
    /// </summary>
    [DllImport("ambxrt.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
    private static extern int amBXCreateInterface(ref IntPtr devicePtr, uint majorVersion, uint minorVersion, string appName,
      string appVer, int memptr, bool usingThreads);

    public void Connect(uint majorVersion, uint minorVersion, string appName, string appVersion, bool useThreads)
    {
      var ptr = IntPtr.Zero;
      try
      {
        amBXCreateInterface(ref ptr, majorVersion, minorVersion, appName, appVersion, 0, useThreads);
      }
      catch (DllNotFoundException)
      {
        throw new amBXrtDllNotFoundException();
      }

      DevicePtr = ptr;
      // Copy the function pointers to our output amBX object
      // Since the layouts match, the pointers should end up in the right slots automatically
      var deviceInterface = Marshal.PtrToStructure<DeviceInterface>(DevicePtr);

      // Generate Delegates
      DeviceDelegates = new DeviceDelegates(deviceInterface);
    }

    public bool IsConnected => DevicePtr != (IntPtr) 0;

    public void CheckConnection()
    {
      if (!IsConnected)
      {
        throw new NotConnectedException();
      }
    }

    public void Disconnect()
    {
      DevicePtr = IntPtr.Zero;
      DeviceDelegates = null;
    }
  }
}
