using System;
using amBXLib.Net.Delegates;
using amBXLib.Net.Exceptions;

namespace amBXLib.Net.Device.Experiences
{
  public class Event : ExperienceBase
  {
    private EventDelegates eventDelegates;

    public Event(string name, IntPtr entityPtr, EventDelegates eventDelegates) : base(name, entityPtr)
    {
      Name = name;
      this.eventDelegates = eventDelegates;
    }

    public void Play()
    {
      ExceptionHelper.CheckForException(eventDelegates.Play(EntityPtr));
    }

    public void Stop()
    {
      ExceptionHelper.CheckForException(eventDelegates.Stop(EntityPtr));
    }

    protected override void Release()
    {
      try
      {
        ExceptionHelper.CheckForException(eventDelegates.Release(EntityPtr));
      }
      finally
      {
        EntityPtr = IntPtr.Zero;
        eventDelegates = null;
      }
    }
  }
}
