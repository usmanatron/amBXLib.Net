using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  /// <summary>
  /// Holds the delegates which connect to functions in DeviceInterface
  /// </summary>
  public class DeviceDelegates
  {
    public readonly ReleaseDelegate Release;
    public readonly CreateLightDelegate CreateLight;
    public readonly CreateFanDelegate CreateFan;
    public readonly CreateRumbleDelegate CreateRumble;
    public readonly CreateMovieDelegate CreateMovie;
    public readonly CreateEventDelegate CreateEvent;
    public readonly SetAllEnabledDelegate SetAllEnabled;
    public readonly UpdateDelegate Update;
    public readonly GetVersionInfoDelegate GetVersionInfo;
    public readonly RunThreadDelegate RunThread;
    public readonly StopThreadDelegate StopThread;

    public DeviceDelegates(DeviceInterface amBXInterface)
    {
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(amBXInterface.ReleasePtr);
      CreateLight = Marshal.GetDelegateForFunctionPointer<CreateLightDelegate>(amBXInterface.CreateLightPtr);
      CreateFan = Marshal.GetDelegateForFunctionPointer<CreateFanDelegate>(amBXInterface.CreateFanPtr);
      CreateRumble = Marshal.GetDelegateForFunctionPointer<CreateRumbleDelegate>(amBXInterface.CreateRumblePtr);
      CreateMovie = Marshal.GetDelegateForFunctionPointer<CreateMovieDelegate>(amBXInterface.CreateMoviePtr);
      CreateEvent = Marshal.GetDelegateForFunctionPointer<CreateEventDelegate>(amBXInterface.CreateEventPtr);
      SetAllEnabled = Marshal.GetDelegateForFunctionPointer<SetAllEnabledDelegate>(amBXInterface.SetAllEnabledPtr);
      Update = Marshal.GetDelegateForFunctionPointer<UpdateDelegate>(amBXInterface.UpdatePtr);
      GetVersionInfo = Marshal.GetDelegateForFunctionPointer<GetVersionInfoDelegate>(amBXInterface.GetVersionInfoPtr);
      RunThread = Marshal.GetDelegateForFunctionPointer<RunThreadDelegate>(amBXInterface.RunThreadPtr);
      StopThread = Marshal.GetDelegateForFunctionPointer<StopThreadDelegate>(amBXInterface.StopThreadPtr);
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult ReleaseDelegate(IntPtr devicePtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult CreateLightDelegate(IntPtr devicePtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr lightPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult CreateFanDelegate(IntPtr devicePtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr fanPtr);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult CreateRumbleDelegate(IntPtr devicePtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr rumblePtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult CreateMovieDelegate(IntPtr devicePtr, [MarshalAs(UnmanagedType.LPArray)] byte[] file, int size, ref IntPtr moviePtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult CreateEventDelegate(IntPtr devicePtr, [MarshalAs(UnmanagedType.LPArray)] byte[] file, int size, ref IntPtr eventPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetAllEnabledDelegate(IntPtr devicePtr, [MarshalAs(UnmanagedType.I1)] bool isEnabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult UpdateDelegate(IntPtr devicePtr, int maxWaitInMilliseconds);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetVersionInfoDelegate(IntPtr devicePtr, ref int major, ref int minor, ref int revision, ref int build);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult RunThreadDelegate(IntPtr devicePtr, amBXThreadType threadType, int threadId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult StopThreadDelegate(IntPtr devicePtr, int threadId);
  }
}