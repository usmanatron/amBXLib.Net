using System;

namespace amBXLib.Net.Device.Experiences
{
  public abstract class ExperienceBase : amBXEntity
  {
    protected ExperienceBase(string name, IntPtr entityPtr) : base(name, entityPtr)
    {
    }
  }
}
