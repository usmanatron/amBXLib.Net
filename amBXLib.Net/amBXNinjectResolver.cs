using amBXLib.Net.Interop;
using Ninject.Modules;

namespace amBXLib.Net
{
  public class amBXNinjectResolver : NinjectModule
  {
    public override void Load()
    {
      Kernel.Bind<amBXDeviceManager>().ToSelf().InSingletonScope();
    }
  }
}
