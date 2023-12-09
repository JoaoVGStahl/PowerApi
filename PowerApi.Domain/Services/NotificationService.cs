using FluentValidation.Results;
using PowerApi.Application.Interfaces;
using PowerApi.Application.Objects;

namespace PowerApi.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<NotificationMessage> _notificationsMessage = new();
        private List<ValidationFailure> _notificationsValidationFailure = new();

        public NotificationService()
        {
            Clear();
        }

        public void Add(NotificationMessage notificationMessage) => _notificationsMessage.Add(notificationMessage);

        public void Add(ValidationFailure validationFailure) => _notificationsValidationFailure.Add(validationFailure);

        public List<NotificationMessage> GetMessages() => _notificationsMessage;

        public List<ValidationFailure> GetValidationFailures() => _notificationsValidationFailure;

        public void Clear()
        {
            _notificationsMessage = new List<NotificationMessage>();
            _notificationsValidationFailure = new List<ValidationFailure>();
        }
    }
}
