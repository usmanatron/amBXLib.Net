namespace amBXLib.Net.Exceptions
{
  public class OutOfMemoryException : amBXException
  {
    public OutOfMemoryException() : base(amBXOperationResult.OutOfMemory, "Could not allocate memory.")
    {
    }
  }
}