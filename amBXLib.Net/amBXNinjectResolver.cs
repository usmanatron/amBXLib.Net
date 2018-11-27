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
      Kernel.Bind<IComponentFactory<Light>>().To<LightFactory>();
      Kernel.Bind<IComponentFactory<Fan>>().To<FanFactory>();
      Kernel.Bind<IComponentFactory<Rumble>>().To<RumbleFactory>();
    }
  }
}
