

namespace Event;


public class EventStore
{    
    public event EventHandler<IEvent>? RaiseEvent;

    private List<IEvent> _eventStoreList = new List<IEvent>();
    //Simulate pushing to DB, here just using in memory list

    public void PublishEvent(IEvent evt)
    {
        _eventStoreList.Add(evt);
        RaiseEvent?.Invoke(this, evt);
    }

    public void Subscribe(EventHandler<IEvent> handler)
    {
        //Subscribe to the event with a specific eventType
        RaiseEvent += handler;
    }

    public List<IEvent> GetEventStoreList()
    {
        return _eventStoreList;
    }
}

