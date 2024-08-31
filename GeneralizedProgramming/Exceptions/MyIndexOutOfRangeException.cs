namespace GeneralizedProgramming.Exceptions
{
    public class MyIndexOutOfRangeException : ListException
    {
        public MyIndexOutOfRangeException() { }

        public MyIndexOutOfRangeException(string message) : base(message) { }
    }
}
