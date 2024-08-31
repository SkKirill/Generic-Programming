namespace GeneralizedProgramming.Exceptions
{
    public class MyNullReferenceException : ListException
    {
        public MyNullReferenceException() { }

        public MyNullReferenceException(string message) : base(message) { }
    }
}
