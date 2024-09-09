using CycleTracker.Application.Notifications;

namespace CycleTracker.API.Controllers.V1;

public class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}