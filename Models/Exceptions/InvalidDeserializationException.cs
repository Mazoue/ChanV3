namespace Models.Exceptions
{
    public class InvalidDeserializationException : Exception
    {
        public InvalidDeserializationException()
        {
        }

        public InvalidDeserializationException(string message) : base(message)
        {
        }

        public InvalidDeserializationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}