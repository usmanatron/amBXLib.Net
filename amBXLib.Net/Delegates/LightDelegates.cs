using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  public class LightDelegates : ComponentDelegates
  {
    public readonly SetColDelegate SetCol;
    public readonly GetColDelegate GetCol;
    public readonly SetFadeTimeDelegate SetFadeTime;
    public readonly GetFadeTimeDelegate GetFadeTime;
    public readonly SetEnabledDelegate SetEnabled;
    public readonly GetEnabledDelegate GetEnabled;
    public readonly SetUpdatePropertiesDelegate SetUpdateProperties;
    public readonly GetUpdatePropertiesDelegate GetUpdateProperties;

    public LightDelegates(LightInterface lightInterface)
    {
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(lightInterface.ReleasePtr);
      GetCol = Marshal.GetDelegateForFunctionPointer<GetColDelegate>(lightInterface.GetColPtr);
      SetCol = Marshal.GetDelegateForFunctionPointer<SetColDelegate>(lightInterface.SetColPtr);
      GetFadeTime = Marshal.GetDelegateForFunctionPointer<GetFadeTimeDelegate>(lightInterface.GetFadeTimePtr);
      SetFadeTime = Marshal.GetDelegateForFunctionPointer<SetFadeTimeDelegate>(lightInterface.SetFadeTimePtr);
      GetLocation = Marshal.GetDelegateForFunctionPointer<GetLocationDelegate>(lightInterface.GetLocationPtr);
      GetEnabled = Marshal.GetDelegateForFunctionPointer<GetEnabledDelegate>(lightInterface.GetEnabledPtr);
      SetEnabled = Marshal.GetDelegateForFunctionPointer<SetEnabledDelegate>(lightInterface.SetEnabledPtr);
      SetUpdateProperties =
        Marshal.GetDelegateForFunctionPointer<SetUpdatePropertiesDelegate>(lightInterface.SetUpdatePropertiesPtr);
      GetUpdateProperties =
        Marshal.GetDelegateForFunctionPointer<GetUpdatePropertiesDelegate>(lightInterface.GetUpdatePropertiesPtr);

    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetColDelegate(IntPtr lightPtr, float red, float green, float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetColDelegate(IntPtr lightPtr, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetFadeTimeDelegate(IntPtr lightPtr, int fadeTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetFadeTimeDelegate(IntPtr lightPtr, ref int fadeTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetEnabledDelegate(IntPtr lightPtr, [MarshalAs(UnmanagedType.I1)] bool isEnabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetEnabledDelegate(IntPtr lightPtr, [MarshalAs(UnmanagedType.I1)] ref bool isEnabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetUpdatePropertiesDelegate(IntPtr lightPtr, Int64 lightUpdateInterval, float lightDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetUpdatePropertiesDelegate(IntPtr lightPtr, ref Int64 lightUpdateInterval, ref float lightDelta);
  }
}
