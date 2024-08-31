namespace GeneralizedProgramming.Exceptions
{
    public class MyNotFoundException : ListException
    {
        public MyNotFoundException() { }

        public MyNotFoundException(string message) : base(message) { }
    }
}
