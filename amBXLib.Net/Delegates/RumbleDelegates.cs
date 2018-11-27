using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  public class RumbleDelegates : ComponentDelegates
  {
    public readonly SetRumbleDelegate SetRumble;
    public readonly GetRumbleDelegate GetRumble;
    public readonly GetEnabledDelegate GetEnabled;
    public readonly SetEnabledDelegate SetEnabled;
    public readonly SetUpdatePropertiesDelegate SetUpdateProperties;
    public readonly GetUpdatePropertiesDelegate GetUpdateProperties;

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
    public delegate amBXOperationResult SetRumbleDelegate(IntPtr rumblePtr, string name, float speed, float intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetRumbleDelegate(IntPtr rumblePtr, int maxLen, string name, ref int length, ref float speed, ref float intensity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetEnabledDelegate(IntPtr rumblePtr, ref ComponentEnabled state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetEnabledDelegate(IntPtr rumblePtr, [MarshalAs(UnmanagedType.I1)] bool isEnabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetUpdatePropertiesDelegate(IntPtr rumblePtr, Int64 rumbleUpdateInterval, float speedDelta, float intensityDelta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetUpdatePropertiesDelegate(IntPtr rumblePtr, ref Int64 rumbleUpdateInterval, ref float speedDelta, ref float intensityDelta);
  }
}
