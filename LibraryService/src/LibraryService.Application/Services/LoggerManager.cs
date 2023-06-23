using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using NLog;
using System.Linq;

namespace LibraryService.Application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }
        
        public void LogError(ErrorResult errorResult)
        {
            string message = String.Join(',',errorResult.Messages);
            logger.Error(message);
        }

        public void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
