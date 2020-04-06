namespace Student.API.Configuration
{
    public class AppConfiguration
    {
        public ConnectionStringsInfo ConnectionStrings { get; set; }
        public LoogingInfo Logging { get; set; }
    }

    public class ConnectionStringsInfo
    {
        public string StudentConnection { get; set; }
    }

    public class LoogingInfo
    {
        public LogLevelInfo LogLevel { get; set; }
    }

    public class LogLevelInfo
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        
    }
}