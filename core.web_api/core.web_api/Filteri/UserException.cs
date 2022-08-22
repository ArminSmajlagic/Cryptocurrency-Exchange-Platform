namespace core.web_api.Filteri
{
    public class UserException : Exception
    {
        //customization to user exception can be added here
        public UserException(string msg) : base(msg)
        {

        }
    }
}
