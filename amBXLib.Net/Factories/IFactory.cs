using amBXLib.Net.Device.Components;

namespace amBXLib.Net.Factories
{
  public interface IFactory<out T> where T : ComponentBase
  {
    T Create(string name, ComponentDirection direction, ComponentHeight componentHeight);
  }
}