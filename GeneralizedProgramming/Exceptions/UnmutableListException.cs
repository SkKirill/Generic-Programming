namespace GeneralizedProgramming.Exceptions
{
    public class UnmutableListException : ListException
    {
        public UnmutableListException() { }

        public UnmutableListException(string message) : base(message) { }
    }
}
