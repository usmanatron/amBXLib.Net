using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Interop
{
  /// <summary>
  /// Holds the delegates which connect to functions in DeviceInterface
  /// </summary>
  public class DeviceDelegates
  {
    public ReleaseDelegate Release;
    public CreateLightDelegate CreateLight;
    public CreateFanDelegate CreateFan;
    public CreateRumbleDelegate CreateRumble;
    public CreateMovieDelegate CreateMovie;
    public CreateEventDelegate CreateEvent;
    public SetAllEnabledDelegate SetAllEnabled;
    public UpdateDelegate Update;
    public GetVersionInfoDelegate GetVersionInfo;
    public RunThreadDelegate RunThread;
    public StopThreadDelegate StopThread;

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
    public delegate amBX_RESULT ReleaseDelegate(IntPtr IamBXPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT CreateLightDelegate(IntPtr IamBXPtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr IamBXLightPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT CreateFanDelegate(IntPtr IamBXPtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr amBXFanPtr);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT CreateRumbleDelegate(IntPtr IamBXPtr, ComponentDirection componentDirection, ComponentHeight componentHeight, ref IntPtr amBXRumble);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT CreateMovieDelegate(IntPtr IamBXPtr, [MarshalAs(UnmanagedType.LPArray)] byte[] File, int Size, ref IntPtr MoviePtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT CreateEventDelegate(IntPtr IamBXPtr, [MarshalAs(UnmanagedType.LPArray)] byte[] File, int Size, ref IntPtr EventPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetAllEnabledDelegate(IntPtr IamBXPtr, [MarshalAs(UnmanagedType.I1)] bool Enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT UpdateDelegate(IntPtr IamBXPtr, int MaxWaitInMilliseconds);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetVersionInfoDelegate(IntPtr IamBXPtr, ref int Major, ref int Minor, ref int Revision, ref int Build);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT RunThreadDelegate(IntPtr IamBXPtr, amBX_ThreadType ThreadType, int ThreadID);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT StopThreadDelegate(IntPtr IamBXPtr, int ThreadID);
  }
}