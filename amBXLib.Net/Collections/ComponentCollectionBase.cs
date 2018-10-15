using System.Collections.Generic;
using System.Linq;
using amBXLib.Net.Components;

namespace amBXLib.Net.Collections
{
  public class ComponentCollectionBase<C> : List<C> where C : ComponentBase
  {
    public void DisconnectAll()
    {
      this.ForEach(c => c.Dispose());
      this.Clear();
    }

    public void EnableAll()
    {
      this.ForEach(c => c.Enable());
    }

    public void DisableAll()
    {
      this.ForEach(c => c.Disable());
    }

    public List<C> WithDirection(ComponentDirection location)
    {
      return this.Where(c => c.Location == location).ToList();
    }

  }
}
