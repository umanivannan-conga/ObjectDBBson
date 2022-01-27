﻿using System.Runtime.InteropServices;


namespace ObjectDB;

internal static class IOExceptionExtensions
{
    private const int ERROR_SHARING_VIOLATION = 32;
    private const int ERROR_LOCK_VIOLATION = 33;

    /// <summary>
    /// Detect if exception is an Locked exception
    /// </summary>
    public static bool IsLocked(this IOException ex)
    {
        var errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);

        return
            errorCode == ERROR_SHARING_VIOLATION ||
            errorCode == ERROR_LOCK_VIOLATION;
    }

    /// <summary>
    /// Wait current thread for N milliseconds if exception is about Locking
    /// </summary>
    public static void WaitIfLocked(this IOException ex, int timerInMilliseconds)
    {
        if (ex.IsLocked())
        {
            if (timerInMilliseconds > 0)
            {
                System.Threading.Tasks.Task.Delay(timerInMilliseconds).Wait();
            }
        }
        else
        {
            throw ex;
        }
    }
}