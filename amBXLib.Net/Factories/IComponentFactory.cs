using amBXLib.Net.Device.Components;
using amBXLib.Net.Device.Experiences;

namespace amBXLib.Net.Factories
{
  public interface IComponentFactory<out T> where T : ComponentBase
  {
    T Create(string name, ComponentDirection direction, ComponentHeight componentHeight);
  }

  public interface IExperienceFactory<out T> where T : ExperienceBase
  {
    T Create(string name, byte[] fileContents);
  }

}