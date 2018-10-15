using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Interop
{
  public class LightDelegates
  {
    public ReleaseDelegate Release;
    public SetColDelegate SetCol;
    public GetColDelegate GetCol;
    public SetFadeTimeDelegate SetFadeTime;
    public GetFadeTimeDelegate GetFadeTime;
    public GetLocationDelegate GetLocation;
    public SetEnabledDelegate SetEnabled;
    public GetEnabledDelegate GetEnabled;
    public SetUpdatePropertiesDelegate SetUpdateProperties;
    public GetUpdatePropertiesDelegate GetUpdateProperties;

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
    public delegate amBX_RESULT ReleaseDelegate(IntPtr IamBXLightPtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetColDelegate(IntPtr IamBXLight, float fRed, float fGreen, float fBlue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetColDelegate(IntPtr IamBXLight, ref float fRed, ref float fGreen, ref float fBlue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetFadeTimeDelegate(IntPtr IamBXLightPtr, int FadeTimeMS);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetFadeTimeDelegate(IntPtr IamBXLightPtr, ref int FadeTimeMS);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetLocationDelegate(IntPtr IamBXLightPtr, ref ComponentDirection Location);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetEnabledDelegate(IntPtr IamBXLightPtr, [MarshalAs(UnmanagedType.I1)] bool Enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetEnabledDelegate(IntPtr IamBXLightPtr, [MarshalAs(UnmanagedType.I1)] ref bool Enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT SetUpdatePropertiesDelegate(IntPtr IamBXLightPtr, Int64 LightUpdateIntervalMS, float fLightDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBX_RESULT GetUpdatePropertiesDelegate(IntPtr IamBXLightPtr, ref Int64 lightUpdateIntervalMS, ref float fLightDelta);
  }
}
