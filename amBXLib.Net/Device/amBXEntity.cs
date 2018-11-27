using System;

namespace amBXLib.Net.Device
{
  public abstract class amBXEntity : IDisposable
  {
    protected string Name;
    protected IntPtr EntityPtr;
    private bool disposed;

    protected amBXEntity(string name, IntPtr entityPtr)
    {
      Name = name;
      EntityPtr = entityPtr;
      disposed = false;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          Release();
        }
      }

      disposed = true;
    }

    protected abstract void Release();
  }
}
