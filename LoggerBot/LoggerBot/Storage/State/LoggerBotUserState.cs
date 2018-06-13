using System.Collections.Generic;

namespace LoggerBot.Storage.State
{
    /// <summary>
    /// Class for storing conversation state. 
    /// </summary>
    public class LoggerBotUserState
    {
        public IEnumerable<string> FollowedLogCategories { get; set; } = new string[] { "one", "two", "three" };
    }
}
