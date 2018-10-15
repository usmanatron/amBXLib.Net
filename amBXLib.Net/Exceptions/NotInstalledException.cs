namespace amBXLib.Net.Exceptions
{
  public class NotInstalledException : amBXException
  {
    public NotInstalledException() : base(amBX_RESULT.amBX_NOT_INSTALLED, "amBX is not installed.")
    {
    }

  }
}