using amBXLib.Net.Factories;
using amBXLib.Net.Interop;
using FakeItEasy;
using NUnit.Framework;

namespace amBXLib.Net.Tests.Factories
{
    class LightFactoryTests
    {
      private LightFactory factory;
      private amBXDeviceManager deviceManager;

      [SetUp]
      public void Setup()
      {
        deviceManager = A.Fake<amBXDeviceManager>();
        factory = new LightFactory(deviceManager);
      }

    }
}
