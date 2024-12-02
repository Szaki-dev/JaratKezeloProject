
namespace JaratKezeloProject
{
    public class NegativKesesException : Exception
    {
        public NegativKesesException()
        {
        }

        public NegativKesesException(string? message) : base(message)
        {
        }

        public NegativKesesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}