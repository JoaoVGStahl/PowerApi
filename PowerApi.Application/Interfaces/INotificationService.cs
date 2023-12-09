using FluentValidation.Results;
using PowerApi.Application.Objects;

namespace PowerApi.Application.Interfaces
{
    public interface INotificationService
    {
        void Add(NotificationMessage notificationMessage);
        void Add(ValidationFailure validationFailure);
        List<NotificationMessage> GetMessages();
        List<ValidationFailure> GetValidationFailures();
        void Clear();
    }
}
