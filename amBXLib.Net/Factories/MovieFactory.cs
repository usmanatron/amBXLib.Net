using System;
using System.Runtime.InteropServices;
using amBXLib.Net.Delegates;
using amBXLib.Net.Device;
using amBXLib.Net.Device.Experiences;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interface;

namespace amBXLib.Net.Factories
{
  class MovieFactory : IExperienceFactory<Movie>
  {
    private readonly amBXDeviceManager deviceManager;

    public MovieFactory(amBXDeviceManager deviceManager)
    {
      this.deviceManager = deviceManager;
    }

    public Movie Create(string name, byte[] fileContents)
    {
      var moviePtr = CreateMovie(fileContents);
      var movieInterface = Marshal.PtrToStructure<MovieInterface>(moviePtr);
      var movieDelegates = new MovieDelegates(movieInterface);

      return new Movie(name, moviePtr, movieDelegates);
    }

    private IntPtr CreateMovie(byte[] content)
    {
      deviceManager.CheckConnection();
      var r = new IntPtr();
      ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.CreateMovie(deviceManager.DevicePtr, content, content.Length, ref r));
      return r;
    }
  }
}
