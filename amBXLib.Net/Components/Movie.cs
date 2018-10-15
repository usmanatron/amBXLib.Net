using System;

namespace amBXLib.Net.Components
{
  public class Movie : ComponentBase
    {
      protected override amBX_RESULT GetLocation(ref ComponentDirection location)
      {
        throw new NotImplementedException();
      }

      protected override amBX_RESULT GetIsEnabled(ref ComponentEnabled isEnabled)
      {
        throw new NotImplementedException();
      }

      protected override amBX_RESULT EnableComponent()
      {
        throw new NotImplementedException();
      }

      protected override amBX_RESULT DisableComponent()
      {
        throw new NotImplementedException();
      }

      protected override void Release()
      {
        throw new NotImplementedException();
      }

      public Movie(string name, IntPtr componentPtr) : base(name, componentPtr)
      {
      }
    }
}
/*
 * 


#Region " Movie"
        ''' <summary>
        ''' Represents an amBX Movie object, which is a sequence of effects that can
        ''' be paused or seeked into, and restarted arbitrarily. Mainly used for 
        ''' cutscenes. You should only create movie objects as you need them, and release
        ''' them when done.
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Movie
            Implements IDisposable

            '---- these variables track the interface pointers and delegates used to 
            '     actually communicate with the ambx drivers.
            Private _IamBXMoviePtr As IntPtr
            Private _IamBXMovieInterface As IamBXMovieInterface
            Private _IamBXMovieDelegates As IamBXMovieDelegates


            Private Structure IamBXMovieDelegates
                Public Release As ReleaseDelegate
                Public SetFrozen As SetFrozenDelegate
                Public GetFrozen As GetFrozenDelegate
                Public SetSuspended As SetSuspendedDelegate
                Public GetSuspended As GetSuspendedDelegate
                Public Seek As SeekDelegate


                Public Sub Generate(ByVal IamBXMovieInterface As IamBXMovieInterface)
                    Me.Release = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.ReleasePtr, GetType(ReleaseDelegate))
                    Me.SetFrozen = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.SetFrozenPtr, GetType(SetFrozenDelegate))
                    Me.GetFrozen = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.GetFrozenPtr, GetType(GetFrozenDelegate))
                    Me.SetSuspended = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.SetSuspendedPtr, GetType(SetSuspendedDelegate))
                    Me.GetSuspended = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.GetSuspendedPtr, GetType(GetSuspendedDelegate))
                    Me.Seek = Marshal.GetDelegateForFunctionPointer(IamBXMovieInterface.SeekPtr, GetType(SeekDelegate))
                End Sub


                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function ReleaseDelegate(ByVal IamBXMoviePtr As IntPtr) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function SetFrozenDelegate(ByVal IamBXMoviePtr As IntPtr, _
                                                           <MarshalAs(UnmanagedType.I1)> ByVal Frozen As Boolean) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function GetFrozenDelegate(ByVal IamBXMoviePtr As IntPtr, _
                                                           <MarshalAs(UnmanagedType.I1)> ByRef Frozen As Boolean) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function SetSuspendedDelegate(ByVal IamBXMoviePtr As IntPtr, _
                                                           <MarshalAs(UnmanagedType.I1)> ByVal Suspended As Boolean) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function GetSuspendedDelegate(ByVal IamBXMoviePtr As IntPtr, _
                                                           <MarshalAs(UnmanagedType.I1)> ByRef Suspended As Boolean) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function SeekDelegate(ByVal IamBXMoviePtr As IntPtr, _
                                                       ByVal Seconds As Single) As amBX_RESULT
            End Structure


            ''' <summary>
            ''' Create a new Movie object based on the contents of a buffer.
            ''' </summary>
            ''' <param name="FileBuffer">
            ''' A byte array containing the event data, preferably read from 
            ''' a bn/ck file.
            ''' </param>
            ''' <remarks></remarks>
            Public Sub New(ByVal FileBuffer As Byte())
                Initialize("", FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Movie object based on the contents of a buffer.
            ''' </summary>
            ''' <param name="FileBuffer">
            ''' A byte array containing the event data, preferably read from 
            ''' a bn/ck file.
            ''' </param>
            ''' <remarks></remarks>
            Public Sub New(ByVal Name As String, ByVal FileBuffer As Byte())
                Initialize(Name, FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Movie object based on the contents of a bn/ck file.
            ''' </summary>
            ''' <param name="FileName"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal FileName As String)
                Dim FileBuffer = System.IO.File.ReadAllBytes(FileName)
                Initialize("", FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Movie object based on the contents of a bn/ck file.
            ''' </summary>
            ''' <param name="FileName"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal Name As String, ByVal FileName As String)
                Dim FileBuffer = System.IO.File.ReadAllBytes(FileName)
                Initialize(Name, FileBuffer)
            End Sub


            ''' <summary>
            ''' Initialize the internal elements and create the Movie interface
            ''' </summary>
            ''' <param name="FileBuffer"></param>
            ''' <remarks></remarks>
            Private Sub Initialize(ByVal Name As String, ByVal FileBuffer As Byte())
                Me.Name = Name
                _IamBXMoviePtr = amBX.CreateMovie(FileBuffer)
                _IamBXMovieInterface = Marshal.PtrToStructure(_IamBXMoviePtr, GetType(IamBXMovieInterface))
                _IamBXMovieDelegates.Generate(_IamBXMovieInterface)

                amBX.Movies.Add(Me)
            End Sub


            ''' <summary>
            ''' Name of this Movie
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Name() As String
                Get
                    Return _Name
                End Get
                Set(ByVal value As String)
                    _Name = value
                End Set
            End Property
            Private _Name As String


            Private Sub Release()
                Try
                    Exceptions.Check(_IamBXMovieDelegates.Release(_IamBXMoviePtr), "Unable to release movie object")
                Finally
                    _IamBXMovieInterface = New IamBXMovieInterface
                    _IamBXMovieDelegates = New IamBXMovieDelegates
                    _IamBXMoviePtr = 0
                End Try
            End Sub


            ''' <summary>
            ''' Method to simplify playing a loaded movie.
            ''' Basically, just Seek to the beginning and unsuspend.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Play()
                Me.Seek(0)
                Me.Suspended = False
            End Sub


            ''' <summary>
            ''' Pause this movie's playback
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Pause()
                Me.Frozen = True
            End Sub


            ''' <summary>
            ''' Continue a paused movie
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub[Continue]()
               Me.Frozen = False
           End Sub


            ''' <summary>
            ''' Stop playback and reset the movie to the beginning.
            ''' </summary>
            ''' <remarks></remarks>

           Public Sub [Stop]()
               Me.Pause()
               Me.Seek(0)
            End Sub


            ''' <summary>
            ''' Sets or retrieves the frozen state of this movie.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Frozen() As Boolean
                Get
                    Dim f As Boolean
                    Exceptions.Check(_IamBXMovieDelegates.GetFrozen(_IamBXMoviePtr, f), "Unable to get movie frozen property")
                    Return f
                End Get
                Set(ByVal value As Boolean)
                    Exceptions.Check(_IamBXMovieDelegates.SetFrozen(_IamBXMoviePtr, value), "Unable to set movie frozen property")
                End Set
            End Property


            ''' <summary>
            ''' Sets or retrieves the suspended state of this move.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Suspended() As Boolean
                Get
                    Dim s As Boolean
                    Exceptions.Check(_IamBXMovieDelegates.GetSuspended(_IamBXMoviePtr, s), "Unable to get movie suspended property")
                    Return s
                End Get
                Set(ByVal value As Boolean)
                    Exceptions.Check(_IamBXMovieDelegates.SetSuspended(_IamBXMoviePtr, value), "Unable to set movie suspended property")
                End Set
            End Property


            ''' <summary>
            ''' Jumps to the specified point in time within the movie. The seek will
            ''' on be made if the absolute difference of the current time 
            ''' and the last seek time is greater than the seek threshold
            ''' (Currently 0.2 seconds).
            ''' </summary>
            ''' <param name="Seconds"></param>
            ''' <remarks></remarks>
            Public Sub Seek(ByVal Seconds As Single)
                Exceptions.Check(_IamBXMovieDelegates.Seek(_IamBXMoviePtr, Seconds), "Unable to seek in movie object")
            End Sub



  */