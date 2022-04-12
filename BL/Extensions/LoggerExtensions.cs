using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace BL.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogAppError<T>(this ILogger<T> logger, Exception exception, string message,
            [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            using var prop = LogContext.PushProperty("MemberName", memberName);
            LogContext.PushProperty("FilePath", sourceFilePath);
            LogContext.PushProperty("LineNumber", sourceLineNumber);
            logger.LogError(exception, message);
        }
    }
}
