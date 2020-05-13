using System;

namespace OrionikUA.ConnectionResults
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
        public static ConnectionResult NotSuccessful(ConnectionResult result) => new ConnectionResult(false, result.Message, result.HasException, result.Exception);
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
        public static ConnectionResult<T> NotSuccessfulObject(ConnectionResult result) => new ConnectionResult<T>(isSuccessful:false, message:result.Message, hasException:result.HasException, exception:result.Exception);
    }

    public class ConnectionResult<T1, T2>
    {
        public T1 ResultObject { get; }
        public T2 ErrorObject { get; }
        public bool IsSuccessful { get; }

        internal ConnectionResult(bool isSuccessful, T1 resultObject = default, T2 errorObject = default)
        {
            IsSuccessful = isSuccessful;
            ResultObject = resultObject;
            ErrorObject = errorObject;
        }

        public static ConnectionResult<T1, T2> Successful(T1 resultObject) => new ConnectionResult<T1, T2>(true, resultObject: resultObject);
        public static ConnectionResult<T1, T2> NotSuccessful(T2 errorObject) => new ConnectionResult<T1, T2>(false, errorObject: errorObject);
    }
}
