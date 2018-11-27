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
  public enum amBXOperationResult
  {
    Ok = 0, // The only one that isn't an error!
    NoSpace = 1, //out of buffer space
    GenericError = 2, //'generic error
    NotFound = 3, //'no file/device etc.found
    amBXVersionNotFound = 4,//'The requested version of amBX API is not available
    BadArguments = 5, //'arguments passed in bad (usually null pointers passed in)
    OutOfRange = 6,//'Value given is beyond usable range using default values if possible
    OutOfMemory = 7,//'couldn't allocate memory
    amBXNotInstalled = 8,//'amBX isn't installed on the PC
    amBXVersionTooOld = 9,//'amBX installed, but need newer version
    EngineLost = 10,//'connection to amBX Engine currently inoperative
    SendTimeout = 11,//'request to send a script timed out
    NotThreaded = 12,//'returned by a threaded function if threading is no being used for the purpose specified
    BadThreadId = 13, //'returned by a function if the thread ID is incorrect or doesn't exist.The thread with the ID could have been recently removed
    ThreadExists = 14, //'returned by a threaded function if a thread is currently being used for that function
    UpdateTimeout = 15,
    //'returned if waiting to perform an update
    //'times out.This could be waiting for a thread
    //'to finish or waiting for a critical section
    ThreadTimeout = 16
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
