using System;

namespace BatchUploaderService.Utilities;

public static class DateTimeUtility
{
    public static string GetTimestamp()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }
}