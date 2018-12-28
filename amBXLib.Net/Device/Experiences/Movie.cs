using System;
using amBXLib.Net.Delegates.Experiences;
using amBXLib.Net.Exceptions;

namespace amBXLib.Net.Device.Experiences
{
  public class Movie : ExperienceBase
  {
    private MovieDelegates movieDelegates;

    public Movie(string name, IntPtr entityPtr, MovieDelegates movieDelegates) : base(name, entityPtr)
    {
      Name = name;
      this.movieDelegates = movieDelegates;
    }

    public void Play()
    {
      Seek(0);
      IsSuspended = false;
    }

    public void Stop()
    {
      Pause();
      Seek(0);
    }

    public void Pause()
    {
      IsFrozen = true;
    }

    public void Continue()
    {
      IsFrozen = false;
    }

    public void Seek(float seconds)
    {
      ExceptionHelper.CheckForException(movieDelegates.Seek(EntityPtr, seconds));
    }

    private bool IsSuspended
    {
      get
      {
        bool s = false;
        ExceptionHelper.CheckForException(movieDelegates.GetSuspended(EntityPtr, ref s));
        return s;
      }
      set => ExceptionHelper.CheckForException(movieDelegates.SetSuspended(EntityPtr, value));
    }

    private bool IsFrozen
    {
      get
      {
        bool s = false;
        ExceptionHelper.CheckForException(movieDelegates.GetFrozen(EntityPtr, ref s));
        return s;
      }
      set => ExceptionHelper.CheckForException(movieDelegates.SetFrozen(EntityPtr, value));
    }

    protected override void Release()
    {
      try
      {
        ExceptionHelper.CheckForException(movieDelegates.Release(EntityPtr));
      }
      finally
      {
        EntityPtr = IntPtr.Zero;
        movieDelegates = null;
      }
    }
  }
}
