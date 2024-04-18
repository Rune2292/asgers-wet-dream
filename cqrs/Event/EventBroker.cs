


namespace Event;

public class EventBroker
{

    public event EventHandler<IEvent>? RaiseEvent;

     public void PublishEvent(IEvent evt)
    {
        RaiseEvent?.Invoke(this, evt);
    }

    public void Subscribe(EventHandler<IEvent> handler)
    {
        //Subscribe to the event with a specific eventType
        RaiseEvent += handler;
    }

    public void Unsubscribe(EventHandler<IEvent> handler)
    {
        //Unsubscribe to the event with a specific eventType
        RaiseEvent -= handler;
    }
}