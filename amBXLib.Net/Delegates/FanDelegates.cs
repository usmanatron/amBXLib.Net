using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  public class FanDelegates : ComponentDelegates
  {
    public readonly SetIntensityDelegate SetIntensity;
    public readonly GetIntensityDelegate GetIntensity;
    public readonly GetEnabledDelegate GetEnabled;
    public readonly SetEnabledDelegate SetEnabled;
    public readonly SetUpdatePropertiesDelegate SetUpdateProperties;
    public readonly GetUpdatePropertiesDelegate GetUpdateProperties;

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
    public delegate amBXOperationResult SetIntensityDelegate(IntPtr fanPtr, float intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetIntensityDelegate(IntPtr fanPtr, ref float intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetEnabledDelegate(IntPtr fanPtr, ComponentEnabled state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetEnabledDelegate(IntPtr fanPtr, ref ComponentEnabled state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetUpdatePropertiesDelegate(IntPtr fanPtr, Int64 fanUpdateInterval, float fanDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetUpdatePropertiesDelegate(IntPtr fanPtr, ref Int64 fanUpdateInterval, ref float fanDelta);
  }
}
