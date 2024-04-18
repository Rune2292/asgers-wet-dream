

namespace Event;


public class EventStore
{    
    private List<IEvent> _eventStoreList = new List<IEvent>();
    //Simulate pushing to DB, here just using in memory list

    public void SaveEvent(IEvent evt)
    {
        _eventStoreList.Add(evt);
    }  

   
    public List<IEvent> GetEventStoreList()
    {
        return _eventStoreList;
    }
}

