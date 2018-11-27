using System;
using amBXLib.Net.Collections;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Device;
using amBXLib.Net.Tasks;

namespace amBXLib.Net
{
  public class amBX
  {
    private readonly amBXDeviceManager deviceManager;
    private readonly MainTaskManager mainTask;
    private readonly AsyncUpdateManager asyncUpdate;
    private int updatesPerSecond;

    public LightCollection Lights { get; }
    public FanCollection Fans { get; }
    public RumbleCollection Rumbles { get; }
    public EventCollection Events { get; }
    public MovieCollection Movies { get; }

    public amBX(amBXDeviceManager deviceManager, MainTaskManager mainTask, AsyncUpdateManager asyncUpdate)
    {
      this.deviceManager = deviceManager;
      this.mainTask = mainTask;
      this.asyncUpdate = asyncUpdate;
      Lights = new LightCollection();
      Fans = new FanCollection();
      Rumbles = new RumbleCollection();
      Events = new EventCollection();
      Movies = new MovieCollection();
    }

    public int UpdatesPerSecond
    {
      get => updatesPerSecond;
      set
      {
        if (value > 0)
        {
          if (updatesPerSecond == 0)
          {
            updatesPerSecond = value;
            // Need to kick-off the background thread
            if (deviceManager.IsConnected)
            {
              mainTask.SetRefreshRate(updatesPerSecond);
              mainTask.Start();
            }
          }
          else
          {
            // Thread should already be running
            updatesPerSecond = value;
          }
        }
        else
        {
          updatesPerSecond = 0;
          mainTask.Stop();
        }
      }
    }

    public void Disconnect()
    {
      deviceManager.CheckConnection();

      try
      {
        try
        {
          Lights.DisconnectAll();
          Fans.DisconnectAll();
          Rumbles.DisconnectAll();
          //Events.DisconnectAll(); //qqUMI
          //Movies.DisconnectAll();
        }
        catch (Exception)
        {
          // Not much we can do...
        }

        if (mainTask.TaskIsRunning())
        {
          mainTask.Stop();
        }
        if (asyncUpdate.TaskIsRunning())
        {
          asyncUpdate.Stop();
        }

        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.Release(deviceManager.DevicePtr));
      }
      finally 
      {
        deviceManager.Disconnect();
      }
    }

    public bool Enabled
    {
      set
      {
        deviceManager.CheckConnection();
        ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.SetAllEnabled(deviceManager.DevicePtr, value));
      }
    }

    public void GetVersionInfo(ref int major, ref int minor, ref int revision, ref int build)
    {
      deviceManager.CheckConnection();
      ExceptionHelper.CheckForException(deviceManager.DeviceDelegates.GetVersionInfo(deviceManager.DevicePtr, ref major, ref minor, ref revision, ref build));
    }
  }
}