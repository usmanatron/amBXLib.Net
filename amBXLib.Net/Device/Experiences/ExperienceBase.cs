using System;

namespace amBXLib.Net.Device.Experiences
{
  /// <summary>
  /// An experience is a more nuanced special effect which is built upon components into its own package
  /// There are two types of experience: event and movie.
  /// </summary>
  public abstract class ExperienceBase : amBXEntity
  {
    protected ExperienceBase(string name, IntPtr entityPtr) : base(name, entityPtr)
    {
    }
  }
}
