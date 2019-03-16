using System;

namespace OrionikUA.DbResults
{
    public class ConnectionResult
    {
        internal ConnectionResult(bool isSuccessful, string message = null, bool hasException = false, Exception exception = null)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            HasException = hasException;
            Exception = exception;
        }

        public bool IsSuccessful { get; }
        public bool HasException { get; }
        public Exception Exception { get; }
        public string Message { get; }

        public static ConnectionResult Successful() => new ConnectionResult(true);
        public static ConnectionResult NotSuccessful(Exception exception) => new ConnectionResult(false, hasException: true, exception: exception);
        public static ConnectionResult NotSuccessful(string message) => new ConnectionResult(false, message);
    }

    public class ConnectionResult<T> : ConnectionResult
    {
        public T ResultObject { get; set; }

        internal ConnectionResult(T resultObject = default(T), bool isSuccessful = true, string message = null, bool hasException = false, Exception exception = null)
            : base(isSuccessful, message, hasException, exception)
        {
            ResultObject = resultObject;
        }

        public static ConnectionResult<T> SuccessfulObject(T resultObject) => new ConnectionResult<T>(resultObject);
        public static ConnectionResult<T> NotSuccessfulObject(Exception exception) => new ConnectionResult<T>(isSuccessful: false, hasException: true, exception: exception);
        public static ConnectionResult<T> NotSuccessfulObject(string message) => new ConnectionResult<T>(isSuccessful: false, message: message);
    }
}
