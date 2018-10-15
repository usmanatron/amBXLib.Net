namespace amBXLib.Net.Exceptions
{
  public class NotFoundException : amBXException
  {
    public NotFoundException() : base(amBX_RESULT.amBX_NOT_FOUND, "File or device not found.")
    {
    }
  }
}