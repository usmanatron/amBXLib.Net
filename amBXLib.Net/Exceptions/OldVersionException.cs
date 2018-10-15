namespace amBXLib.Net.Exceptions
{
  public class OldVersionException : amBXException
  {


    public OldVersionException() : base(amBX_RESULT.amBX_OLD_VERSION, "amBX is installed, but is not the right version.")
    {
    }
  }
}