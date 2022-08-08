namespace Models.Exceptions
{
    public class PostServiceException : Exception
    {
        public PostServiceException()
        {
        }

        public PostServiceException(string message) : base(message)
        {
        }

        public PostServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}