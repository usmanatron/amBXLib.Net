using System;

namespace amBXLib.Net.Exceptions
{
  static class ExceptionHelper
  {
    public static void CheckForException(amBX_RESULT result)
    {
      switch (result)
      {
        case amBX_RESULT.amBX_OK:
          break;
        case amBX_RESULT.amBX_NO_SPACE:
          throw new NoSpaceException();
        case amBX_RESULT.amBX_ERROR:
          throw new GeneralErrorException();
        case amBX_RESULT.amBX_NOT_FOUND:
          throw new NotFoundException();
        case amBX_RESULT.amBX_VERSION_NOT_FOUND:
          throw new VersionNotFoundException();
        case amBX_RESULT.amBX_BAD_ARGS:
          throw new BadArgsException();
        case amBX_RESULT.amBX_OUT_OF_RANGE:
          throw new OutOfRangeException();
        case amBX_RESULT.amBX_OUT_OF_MEMORY:
          throw new OutOfMemoryException();
        case amBX_RESULT.amBX_NOT_INSTALLED:
          throw new NotInstalledException();
        case amBX_RESULT.amBX_OLD_VERSION:
          throw new OldVersionException();
        case amBX_RESULT.amBX_ENGINE_LOST:
          throw new ConnectionLostException();
        case amBX_RESULT.amBX_SENDING_TIMEOUT:
          throw new SendTimeoutException();
        case amBX_RESULT.amBX_NOT_THREADED:
          throw new NotThreadedException();
        case amBX_RESULT.amBX_BAD_THREADID:
          throw new BadThreadIdException();
        case amBX_RESULT.amBX_THREAD_EXISTS:
          throw new ThreadExistsException();
        case amBX_RESULT.amBX_UPDATE_TIMEOUT:
          throw new UpdateTimeoutException();
        case amBX_RESULT.amBX_THREAD_TIMEOUT:
          throw new ThreadTimeoutException();
        default:
          throw new ArgumentOutOfRangeException(nameof(result), result, null);
      }
    }
  }
}