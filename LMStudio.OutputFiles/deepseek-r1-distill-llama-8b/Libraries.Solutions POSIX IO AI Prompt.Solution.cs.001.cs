try
{
    var invalidDescriptor = new OpenFileDescriptor();
    // Invalid operations throw specific exceptions
    invalidDescriptor.Read(new byte[1024]);
}
catch (InvalidFileDescriptorException)
{
    // Handle error appropriately
}