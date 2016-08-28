namespace Generics
{
    public class OperationResult<T> where T : struct 
    {
        public OperationResult()
        {
            
        }

        public OperationResult(T result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public T Result { get; set; }
        public string Message { get; set; }
    }
}