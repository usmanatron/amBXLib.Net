using amBXLib.Net.Device;
using amBXLib.Net.Device.Components;
using amBXLib.Net.Factories;
using Ninject.Modules;

namespace amBXLib.Net
{
  public class amBXNinjectResolver : NinjectModule
  {
    public override void Load()
    {
      Kernel.Bind<amBXDeviceManager>().ToSelf().InSingletonScope();
      Kernel.Bind<IFactory<Light>>().To<LightFactory>();
      Kernel.Bind<IFactory<Fan>>().To<FanFactory>();
      Kernel.Bind<IFactory<Rumble>>().To<RumbleFactory>();
    }
  }
}
