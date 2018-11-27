namespace amBXLib.Net.Exceptions
{
  public class BadThreadIdException : amBXException
  {
    public BadThreadIdException() : base(amBXOperationResult.BadThreadId, "A thread ID is incorrect or doesn't exist.")
    {
    }
  }
}