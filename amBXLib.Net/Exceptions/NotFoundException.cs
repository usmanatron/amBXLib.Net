namespace amBXLib.Net.Exceptions
{
  public class NotFoundException : amBXException
  {
    public NotFoundException() : base(amBXOperationResult.NotFound, "File or device not found.")
    {
    }
  }
}