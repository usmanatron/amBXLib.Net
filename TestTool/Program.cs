using System;
using System.Threading;
using amBXLib.Net;
using amBXLib.Net.Helpers;
using Ninject;

namespace TestTool
{
  class Program
  {
    static void Main(string[] args)
    {
      var kernel = new StandardKernel();
      kernel.Load(AppDomain.CurrentDomain.GetAssemblies());

      var amBX = kernel.Get<amBXBuilder>()
        .WithConnection(1, 0, "test-tool", "1,0", true)
        .WithLight(ComponentDirection.North, ComponentHeight.AnyHeight, "1")
        .WithLight(ComponentDirection.NorthEast, ComponentHeight.AnyHeight, "2")
        .WithLight(ComponentDirection.East, ComponentHeight.AnyHeight, "3")
        .WithLight(ComponentDirection.SouthEast, ComponentHeight.AnyHeight, "4")
        .WithLight(ComponentDirection.South, ComponentHeight.AnyHeight, "5")
        .WithLight(ComponentDirection.SouthWest, ComponentHeight.AnyHeight, "6")
        .WithLight(ComponentDirection.West, ComponentHeight.AnyHeight, "7")
        .WithLight(ComponentDirection.NorthWest, ComponentHeight.AnyHeight, "8")
        .WithRefreshRate(50)
        .Build();

      amBX.Lights.WithDirection(ComponentDirection.North)[0].Colour = new Colour(1f, 0f, 0f);
      amBX.Lights.WithDirection(ComponentDirection.East)[0].Colour = new Colour(0f, 1f, 0f);
      amBX.Lights.WithDirection(ComponentDirection.South)[0].Colour = new Colour(0f, 0f, 1f);


      while (true)
      {
        Thread.Sleep(1000);
        if (Console.CapsLock)
        {
          break;
        }

      }
      amBX.Lights.DisconnectAll();
      amBX.Disconnect();
    }


  }
}
