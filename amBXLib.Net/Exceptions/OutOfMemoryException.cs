namespace amBXLib.Net.Exceptions
{
  public class OutOfMemoryException : amBXException
  {
    public OutOfMemoryException() : base(amBX_RESULT.amBX_OUT_OF_MEMORY, "Could not allocate memory.")
    {
    }
  }
}