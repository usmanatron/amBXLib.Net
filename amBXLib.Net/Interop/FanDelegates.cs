using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Interop
{
  public class FanDelegates
  {
    public ReleaseDelegate Release;
    public SetIntensityDelegate SetIntensity;
    public GetIntensityDelegate GetIntensity;
    public GetLocationDelegate GetLocation;
    public GetEnabledDelegate GetEnabled;
    public SetEnabledDelegate SetEnabled;
    public SetUpdatePropertiesDelegate SetUpdateProperties;
    public GetUpdatePropertiesDelegate GetUpdateProperties;

    public FanDelegates(FanInterface fanInterface)
    {
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(fanInterface.ReleasePtr);
      GetIntensity = Marshal.GetDelegateForFunctionPointer<GetIntensityDelegate>(fanInterface.GetIntensityPtr);
      SetIntensity = Marshal.GetDelegateForFunctionPointer<SetIntensityDelegate>(fanInterface.SetIntensityPtr);
      GetLocation = Marshal.GetDelegateForFunctionPointer<GetLocationDelegate>(fanInterface.GetLocationPtr);
      GetEnabled = Marshal.GetDelegateForFunctionPointer<GetEnabledDelegate>(fanInterface.GetEnabledPtr);
      SetEnabled = Marshal.GetDelegateForFunctionPointer<SetEnabledDelegate>(fanInterface.SetEnabledPtr);
      SetUpdateProperties = Marshal.GetDelegateForFunctionPointer<SetUpdatePropertiesDelegate>(fanInterface.SetUpdatePropertiesPtr);
      GetUpdateProperties = Marshal.GetDelegateForFunctionPointer<GetUpdatePropertiesDelegate>(fanInterface.GetUpdatePropertiesPtr);
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT ReleaseDelegate(IntPtr fanPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetIntensityDelegate(IntPtr fanPtr, float Intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetIntensityDelegate(IntPtr fanPtr, ref float Intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetLocationDelegate(IntPtr fanPtr, ref ComponentDirection Location);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetEnabledDelegate(IntPtr fanPtr, ComponentEnabled State);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetEnabledDelegate(IntPtr fanPtr, ref ComponentEnabled State);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetUpdatePropertiesDelegate(IntPtr fanPtr, Int64 FanUpdateIntervalMS, float fFanDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetUpdatePropertiesDelegate(IntPtr fanPtr, ref Int64 FanUpdateIntervalMS, ref float FanDelta);
  }
}
