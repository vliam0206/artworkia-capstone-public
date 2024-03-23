using Application.Commons;
using Application.Models;
using Domain.Entities.Commons;

namespace Application.Services.Abstractions;

public interface INotificationService
{
    Task AddNotificationAsync(NotificationModel model);
    Task<PagedList<NotificationVM>> GetNotificationsOfAnAccountAsync(Guid accountId, PagedCriteria pagedCriteria);
    Task<NotificationVM> UpdateSeenStateOfNotification(Guid notificationId);
}
