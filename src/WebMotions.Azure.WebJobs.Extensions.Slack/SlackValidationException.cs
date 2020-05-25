using System;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackValidationException : Exception
    {
        public SlackValidationException()
        {
        }

        public SlackValidationException(string message) : base(message)
        {
        }

        public SlackValidationException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}