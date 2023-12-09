namespace PowerApi.Application.Objects
{
    public class NotificationMessage
    {
        public NotificationMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
