using System;
using System.Collections.Generic;
using System.Text;

namespace amBXLib.Net.Components
{
  public class Event : ComponentBase
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

      public Event(string name, IntPtr componentPtr) : base(name, componentPtr)
      {
      }
    }
}
/*
 * 
#Region " Event"
        ''' <summary>
        ''' Create an Event, which is usually a short sequence of effects that cannot
        ''' be paused or seeked into, or an ambience effect which can be simply turned on
        ''' or off.
        ''' </summary>
        ''' <remarks></remarks>
        Public Class[Event]
            Implements IDisposable

            '---- these variables track the interface pointers and delegates used to 
            '     actually communicate with the ambx drivers.
            Private _IamBXEventPtr As IntPtr
            Private _IamBXEventInterface As IamBXEventInterface
            Private _IamBXEventDelegates As IamBXEventDelegates


            <StructLayout(LayoutKind.Sequential)> _
            Private Structure IamBXEventInterface
                Public PlayPtr As IntPtr
                Public StopPtr As IntPtr
                Public ReleasePtr As IntPtr
            End Structure


            Private Structure IamBXEventDelegates
                Public Play As PlayDelegate
                Public[Stop] As StopDelegate
                Public Release As ReleaseDelegate

                Public Sub Generate(ByVal IamBXEventInterface As IamBXEventInterface)
                    Me.Play = Marshal.GetDelegateForFunctionPointer(IamBXEventInterface.PlayPtr, GetType(PlayDelegate))
                    Me.Stop = Marshal.GetDelegateForFunctionPointer(IamBXEventInterface.StopPtr, GetType(StopDelegate))
                    Me.Release = Marshal.GetDelegateForFunctionPointer(IamBXEventInterface.ReleasePtr, GetType(ReleaseDelegate))
                End Sub


                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function PlayDelegate(ByVal IamBXEventPtr As IntPtr) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function StopDelegate(ByVal IamBXEventPtr As IntPtr) As amBX_RESULT

                <UnmanagedFunctionPointer(CallingConvention.Cdecl)> _
                Public Delegate Function ReleaseDelegate(ByVal IamBXEventPtr As IntPtr) As amBX_RESULT
            End Structure


            ''' <summary>
            ''' Create a new Event object based on the contents of a buffer.
            ''' </summary>
            ''' <param name="FileBuffer">
            ''' A byte array containing the event data, preferably read from 
            ''' a bn/ck file. Note, the buffer must contain valid data and cannot
            ''' be nothing or empty.
            ''' </param>
            ''' <remarks></remarks>
            Public Sub New(ByVal FileBuffer As Byte())
                Initialize("", FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Event object based on the contents of a bn/ck file.
            ''' </summary>
            ''' <param name="FileName"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal FileName As String)
                Dim FileBuffer = System.IO.File.ReadAllBytes(FileName)
                Initialize("", FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Event object based on the contents of a buffer.
            ''' </summary>
            ''' <param name="FileBuffer">
            ''' A byte array containing the event data, preferably read from 
            ''' a bn/ck file. Note, the buffer must contain valid data and cannot
            ''' be nothing or empty.
            ''' </param>
            ''' <remarks></remarks>
            Public Sub New(ByVal Name As String, ByVal FileBuffer As Byte())
                Initialize(Name, FileBuffer)
            End Sub


            ''' <summary>
            ''' Create a new Event object based on the contents of a bn/ck file.
            ''' </summary>
            ''' <param name="FileName"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal Name As String, ByVal FileName As String)
                Dim FileBuffer = System.IO.File.ReadAllBytes(FileName)
                Initialize(Name, FileBuffer)
            End Sub


            Private Sub Initialize(ByVal Name As String, ByVal FileBuffer As Byte())
                Me.Name = Name
                _IamBXEventPtr = amBX.CreateEvent(FileBuffer)
                _IamBXEventInterface = Marshal.PtrToStructure(_IamBXEventPtr, GetType(IamBXEventInterface))
                _IamBXEventDelegates.Generate(_IamBXEventInterface)

                amBX.Events.Add(Me)
            End Sub


            ''' <summary>
            ''' Name of this Event
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


            ''' <summary>
            ''' Plays the amBX file loaded when the interface was created.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Play()
                Exceptions.Check(_IamBXEventDelegates.Play(_IamBXEventPtr), "Unable to release event object")
            End Sub


            ''' <summary>
            ''' Stops the playback of the event.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub[Stop]()
               Exceptions.Check(_IamBXEventDelegates.Stop(_IamBXEventPtr), "Unable to stop event object")
            End Sub


            Private Sub Release()
                Try
                    Exceptions.Check(_IamBXEventDelegates.Release(_IamBXEventPtr), "Unable to release event object")
                Finally
                    _IamBXEventInterface = New IamBXEventInterface
                    _IamBXEventDelegates = New IamBXEventDelegates
                    _IamBXEventPtr = 0
                End Try
            End Sub
*/