namespace servisi.trading.Configuration
{
    public static class Constants//or should I say config
    {
        public const string issuer = "https://localhost:7291";//this is the adress of api/server that provides that is authority
        public const string mobile_audience = "http://localhost:1234";//the port is not valid (here goes url for local mobile)
        public const string desktop_audience = "http://localhost:4321";//the port is not valid (here goes url for local desktop)
    }

}
