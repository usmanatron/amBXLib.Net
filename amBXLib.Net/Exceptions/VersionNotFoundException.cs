namespace amBXLib.Net.Exceptions
{
  public class VersionNotFoundException : amBXException
  {
    public VersionNotFoundException()
      : base(amBX_RESULT.amBX_VERSION_NOT_FOUND, "Expected version of amBX API not found.")
    {
    }
  }
}