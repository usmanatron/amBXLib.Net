using amBXLib.Net.Helpers;

namespace amBXLib.Net
{
  /// <summary>
  /// Waveforms that are available for rumble devices
  /// </summary>
  public enum RumbleWaveForms
  {
    [StringValue("amBX_boing")]
    Boing,
    [StringValue("amBX_crash")]
    Crash,
    [StringValue("amBX_engine")]
    Engine,
    [StringValue("amBX_explosion")]
    Explosion,
    [StringValue("amBX_hit")]
    Hit,
    [StringValue("amBX_quake")]
    Quake,
    [StringValue("amBX_rattle")]
    Rattle,
    [StringValue("amBX_road")]
    Road,
    [StringValue("amBX_shot")]
    Shot,
    [StringValue("amBX_thud")]
    Thud,
    [StringValue("amBX_thunder")]
    Thunder
  }

  /// <summary>
  /// The location of a component, represented as compass points
  /// </summary>
  public enum ComponentDirection
  {
    Everywhere = 0,
    North = 1,
    NorthEast = 2,
    East = 4,
    SouthEast = 8,
    South = 16,
    SouthWest = 32,
    West = 64,
    NorthWest = 128,
    Center = 256
  }

  /// <summary>
  /// The height of a component
  /// </summary>
  public enum ComponentHeight
  {
    AnyHeight = 0,
    EveryHeight = 1,
    Top = 2,
    Middle = 4,
    Bottom = 8
  }

  /// <summary>
  /// The available thread types.  Currently there's only one
  /// </summary>
  public enum amBX_ThreadType
  {
    amBX_Ambient_Update = 0
  }

  /// <summary>
  /// The result returned from nearly every call.  The ExceptionHelper class
  /// transforms these into specific exceptions
  /// </summary>
  public enum amBX_RESULT
  {
    amBX_OK = 0, // The only one that isn't an error!
    amBX_NO_SPACE = 1, //out of buffer space
    amBX_ERROR = 2, //'generic error
    amBX_NOT_FOUND = 3, //'no file/device etc.found
    amBX_VERSION_NOT_FOUND = 4,//'The requested version of amBX API is not available
    amBX_BAD_ARGS = 5, //'arguments passed in bad (usually null pointers passed in)
    amBX_OUT_OF_RANGE = 6,//'Value given is beyond usable range using default values if possible
    amBX_OUT_OF_MEMORY = 7,//'couldn't allocate memory
    amBX_NOT_INSTALLED = 8,//'amBX isn't installed on the PC
    amBX_OLD_VERSION = 9,//'amBX installed, but need newer version
    amBX_ENGINE_LOST = 10,//'connection to amBX Engine currently inoperative
    amBX_SENDING_TIMEOUT = 11,//'request to send a script timed out
    amBX_NOT_THREADED = 12,//'returned by a threaded function if threading is no being used for the purpose specified
    amBX_BAD_THREADID = 13, //'returned by a function if the thread ID is incorrect or doesn't exist.The thread with the ID could have been recently removed
    amBX_THREAD_EXISTS = 14, //'returned by a threaded function if a thread is currently being used for that function
    amBX_UPDATE_TIMEOUT = 15,
    //'returned if waiting to perform an update
    //'times out.This could be waiting for a thread
    //'to finish or waiting for a critical section
    amBX_THREAD_TIMEOUT = 16
    //'returned if the request to run a thread times
    //'out.This could be because another thread is
    //'already being run or another thread is using the
    //'resources needed to run the thread
  }

  public enum ComponentEnabled
  {
    ENABLED = 0, //'amBX Currently Enabled
    DISABLED, //'amBX Currently Disabled
    ENABLING, //'amBX in the process of becoming Enabled
    DISABLING //'amBX in the process of becoming Disabled
  }
}
