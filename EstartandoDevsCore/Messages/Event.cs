using MediatR;

namespace EstartandoDevsCore.Messages;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; private set;}

    public Event()
    {
        Timestamp = DateTime.UtcNow;
    }
}
