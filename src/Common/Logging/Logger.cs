using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    using log4net;

    public class Logger
    {
        private readonly ILog log;

        public Logger(Type type)
        {
            this.log = log4net.LogManager.GetLogger(type);
        }

        public void Debug(string message) => this.log.Debug(message);

        public void Debug(string message, Exception exception) => this.log.Debug(message, exception);


        public void Info(string message) => this.log.Debug(message);

        public void Info(string message, Exception exception) => this.log.Debug(message, exception);


        public void Error(string message) => this.log.Debug(message);

        public void Error(string message, Exception exception) => this.log.Debug(message, exception);
    }
}
