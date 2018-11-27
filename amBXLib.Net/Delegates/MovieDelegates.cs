using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Delegates
{
  public class MovieDelegates
  {
    public ReleaseDelegate Release;
    public SetFrozenDelegate SetFrozen;
    public GetFrozenDelegate GetFrozen;
    public SetSuspendedDelegate SetSuspended;
    public GetSuspendedDelegate GetSuspended;
    public SeekDelegate Seek;

    public MovieDelegates(MovieInterface movInterface)
    {
      Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(movInterface.ReleasePtr);
      SetFrozen = Marshal.GetDelegateForFunctionPointer<SetFrozenDelegate>(movInterface.SetFrozenPtr);
      GetFrozen = Marshal.GetDelegateForFunctionPointer<GetFrozenDelegate>(movInterface.GetFrozenPtr);
      SetSuspended = Marshal.GetDelegateForFunctionPointer<SetSuspendedDelegate>(movInterface.SetSuspendedPtr);
      GetSuspended = Marshal.GetDelegateForFunctionPointer<GetSuspendedDelegate>(movInterface.GetSuspendedPtr);
      Seek = Marshal.GetDelegateForFunctionPointer<SeekDelegate>(movInterface.SeekPtr);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult ReleaseDelegate(IntPtr moviePtr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetFrozenDelegate(IntPtr moviePtr, [MarshalAs(UnmanagedType.I1)] bool isFrozen);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetFrozenDelegate(IntPtr moviePtr, [MarshalAs(UnmanagedType.I1)] ref bool isFrozen);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SetSuspendedDelegate(IntPtr moviePtr, [MarshalAs(UnmanagedType.I1)] bool isSuspended);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult GetSuspendedDelegate(IntPtr moviePtr, [MarshalAs(UnmanagedType.I1)] ref bool isSuspended);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate amBXOperationResult SeekDelegate(IntPtr moviePtr, float seconds);
  }
}