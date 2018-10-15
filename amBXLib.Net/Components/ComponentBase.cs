using System;
using amBXLib.Net.Exceptions;

namespace amBXLib.Net.Components
{
  public abstract class ComponentBase : IDisposable
  {
    public string Name;

    protected IntPtr ComponentPtr;
    private bool disposed;

    protected ComponentBase(string name, IntPtr componentPtr)
    {
      Name = name;
      this.ComponentPtr = componentPtr;
      disposed = false;
    }

    public ComponentDirection Location
    {
      get
      {
        ComponentDirection
          location = ComponentDirection.Everywhere; // Assume everywhere, which is technically correct :-p
        ExceptionHelper.CheckForException(GetLocation(ref location));
        return location;
      }
    }
    protected abstract amBX_RESULT GetLocation(ref ComponentDirection location);


    public ComponentEnabled IsEnabled
    {
      get
      {
        var isEnabled = ComponentEnabled.DISABLED; // Assume safest case
        ExceptionHelper.CheckForException(GetIsEnabled(ref isEnabled));
        return isEnabled;
      }
    }
    protected abstract amBX_RESULT GetIsEnabled(ref ComponentEnabled isEnabled);

    public void Enable()
    {
      ExceptionHelper.CheckForException(EnableComponent());
    }
    protected abstract amBX_RESULT EnableComponent();

    public void Disable()
    {
      ExceptionHelper.CheckForException(DisableComponent());
    }
    protected abstract amBX_RESULT DisableComponent();

    #region IDisposable

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          this.Release();
        }
      }

      disposed = true;
    }

    protected abstract void Release();

    #endregion

  }
}
