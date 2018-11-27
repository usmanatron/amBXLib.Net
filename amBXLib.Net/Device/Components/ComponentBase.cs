using System;
using amBXLib.Net.Exceptions;

namespace amBXLib.Net.Device.Components
{
  public abstract class ComponentBase : amBXEntity
  {
    protected ComponentBase(string name, IntPtr componentPtr) : base(name, componentPtr)
    {
    }

    protected IntPtr ComponentPtr => EntityPtr;

    public ComponentDirection Location
    {
      get
      {
        ComponentDirection location = ComponentDirection.Everywhere; // default assumption
        ExceptionHelper.CheckForException(GetLocation(ref location));
        return location;
      }
    }
    protected abstract amBXOperationResult GetLocation(ref ComponentDirection location);


    public ComponentEnabled IsEnabled
    {
      get
      {
        var isEnabled = ComponentEnabled.Disabled; // Assume safest case
        ExceptionHelper.CheckForException(GetIsEnabled(ref isEnabled));
        return isEnabled;
      }
    }
    protected abstract amBXOperationResult GetIsEnabled(ref ComponentEnabled isEnabled);

    public void Enable()
    {
      ExceptionHelper.CheckForException(EnableComponent());
    }
    protected abstract amBXOperationResult EnableComponent();

    public void Disable()
    {
      ExceptionHelper.CheckForException(DisableComponent());
    }
    protected abstract amBXOperationResult DisableComponent();
  }
}
