using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Interop
{
  public class RumbleDelegates
  {
    public ReleaseDelegate Release;
    public SetRumbleDelegate SetRumble;
    public GetRumbleDelegate GetRumble;
    public GetLocationDelegate GetLocation;
    public GetEnabledDelegate GetEnabled;
    public SetEnabledDelegate SetEnabled;
    public SetUpdatePropertiesDelegate SetUpdateProperties;
    public GetUpdatePropertiesDelegate GetUpdateProperties;

    public RumbleDelegates(RumbleInterface rumbleInterface)
    {
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(rumbleInterface.ReleasePtr);
      SetRumble = Marshal.GetDelegateForFunctionPointer<SetRumbleDelegate>(rumbleInterface.SetRumblePtr);
      GetRumble = Marshal.GetDelegateForFunctionPointer<GetRumbleDelegate>(rumbleInterface.GetRumblePtr);
      GetLocation = Marshal.GetDelegateForFunctionPointer<GetLocationDelegate>(rumbleInterface.GetLocationPtr);
      GetEnabled = Marshal.GetDelegateForFunctionPointer<GetEnabledDelegate>(rumbleInterface.GetEnabledPtr);
      SetEnabled = Marshal.GetDelegateForFunctionPointer<SetEnabledDelegate>(rumbleInterface.SetEnabledPtr);
      SetUpdateProperties =
        Marshal.GetDelegateForFunctionPointer<SetUpdatePropertiesDelegate>(rumbleInterface.SetUpdatePropertiesPtr);
      GetUpdateProperties =
        Marshal.GetDelegateForFunctionPointer<GetUpdatePropertiesDelegate>(rumbleInterface.GetUpdatePropertiesPtr);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT ReleaseDelegate(IntPtr IamBXRumble);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetRumbleDelegate(IntPtr IamBXRumble,
      string RumbleName,
      float Speed,
      float Intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetRumbleDelegate(IntPtr IamBXRumblePtr,
      int MaxLen,
      string RumbleName,
      ref int Length,
      ref float Speed,
      ref float Intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetLocationDelegate(IntPtr IamBXRumblePtr, ref ComponentDirection Location);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetEnabledDelegate(IntPtr IamBXRumblePtr, ref ComponentEnabled State);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetEnabledDelegate(IntPtr IamBXRumblePtr, [MarshalAs(UnmanagedType.I1)] bool Enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetUpdatePropertiesDelegate(IntPtr IamBXRumblePtr, Int64 RumbleUpdateIntervalMS,
      float fSpeedDelta,
      float IntensityDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetUpdatePropertiesDelegate(IntPtr IamBXRumblePtr,
      ref Int64 RumbleUpdateIntervalMS,
      ref float SpeedDelta,
      ref float IntensityDelta);
  }
}
