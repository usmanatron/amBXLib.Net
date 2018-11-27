using System;

namespace amBXLib.Net.Exceptions
{
  static class ExceptionHelper
  {
    public static void CheckForException(amBXOperationResult result)
    {
      switch (result)
      {
        case amBXOperationResult.Ok:
          break;
        case amBXOperationResult.NoSpace:
          throw new NoSpaceException();
        case amBXOperationResult.GenericError:
          throw new GeneralErrorException();
        case amBXOperationResult.NotFound:
          throw new NotFoundException();
        case amBXOperationResult.amBXVersionNotFound:
          throw new VersionNotFoundException();
        case amBXOperationResult.BadArguments:
          throw new BadArgsException();
        case amBXOperationResult.OutOfRange:
          throw new OutOfRangeException();
        case amBXOperationResult.OutOfMemory:
          throw new OutOfMemoryException();
        case amBXOperationResult.amBXNotInstalled:
          throw new NotInstalledException();
        case amBXOperationResult.amBXVersionTooOld:
          throw new OldVersionException();
        case amBXOperationResult.EngineLost:
          throw new ConnectionLostException();
        case amBXOperationResult.SendTimeout:
          throw new SendTimeoutException();
        case amBXOperationResult.NotThreaded:
          throw new NotThreadedException();
        case amBXOperationResult.BadThreadId:
          throw new BadThreadIdException();
        case amBXOperationResult.ThreadExists:
          throw new ThreadExistsException();
        case amBXOperationResult.UpdateTimeout:
          throw new UpdateTimeoutException();
        case amBXOperationResult.ThreadTimeout:
          throw new ThreadTimeoutException();
        default:
          throw new ArgumentOutOfRangeException(nameof(result), result, "Unexpected exception type returned");
      }
    }
  }
}