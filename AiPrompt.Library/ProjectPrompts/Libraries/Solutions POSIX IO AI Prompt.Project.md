
# Application Description
 
- **Create an in-memory library that simulates POSIX I/O file descriptors and their associated system calls. This library should include the following functionalities**

- **File Descriptors**: Implement abstractions for accessing files, devices, and I/O streams using standard file descriptors. The library should handle the standard file descriptors: `0` for `stdin`, `1` for `stdout`, and `2` for `stderr`.

- **System Calls**: Implement essential POSIX system calls such as `open`, `read`, `write`, `close`, and `lseek`. Ensure that these functions can handle operations on in-memory data structures which simulate file behavior.

- **Standard Streams**: Provide functionality equivalent to standard C I/O functions like `fopen`, `fwrite`, and `fprintf`, but re-implemented to operate on your in-memory library instead of actual disk files.

- **Pipes and Redirection**: Implement mechanisms to allow inter-process communication using pipes and the ability to redirect output streams to your in-memory structures.

- **Uniform Treatment of Devices**: Ensure that devices (simulated as files) are treated uniformly so that all I/O operations are seamless and consistent across file types and streams.

- **Consider edge cases such as error handling for invalid file descriptors, handling of EOF conditions, and synchronization if your library will be used in a multi-threaded context.**