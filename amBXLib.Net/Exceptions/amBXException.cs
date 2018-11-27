using System;

namespace amBXLib.Net.Exceptions
{
  /// <summary>
  /// Base amBX Exception
  /// </summary>
  public class amBXException : Exception
  {
    public amBXOperationResult ErrorNumber { get; }

    public amBXException(amBXOperationResult errorNumber, string message) : base(message)
    {
      ErrorNumber = errorNumber;
    }
  }
}
