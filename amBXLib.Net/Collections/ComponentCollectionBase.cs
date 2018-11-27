using System.Collections.Generic;
using System.Linq;
using amBXLib.Net.Device.Components;

namespace amBXLib.Net.Collections
{
  public class ComponentCollectionBase<C> : List<C> where C : ComponentBase
  {
    public void DisconnectAll()
    {
      ForEach(c => c.Dispose());
      Clear();
    }

    public void EnableAll()
    {
      ForEach(c => c.Enable());
    }

    public void DisableAll()
    {
      ForEach(c => c.Disable());
    }

    public List<C> WithDirection(ComponentDirection location)
    {
      return this.Where(c => c.Location == location).ToList();
    }

  }
}
