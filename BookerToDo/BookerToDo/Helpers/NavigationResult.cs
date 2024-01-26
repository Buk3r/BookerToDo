using System;

namespace BookerToDo.Helpers
{
    public class NavigationResult
    {
        #region -- Public properties --

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public Exception Exception { get; private set; }

        #endregion

        #region -- Public methods --

        public void SetSuccess()
        {
            SetResult(true, null, null);
        }

        public void SetError()
        {
            SetResult(false, null, null);
        }

        public void SetError(string message)
        {
            SetResult(false, message, null);
        }

        public void SetException(Exception exception)
        {
            SetResult(false, null, exception);
        }

        #endregion

        #region -- Private methods --

        private void SetResult(bool isSuccess, string message, Exception exception)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = exception;
        }

        #endregion
    }
}