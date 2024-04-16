
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Components.Web;

using Cmd;

namespace Event;


public class EventStore
{    
    public event EventHandler<IEvent>? RaiseEvent;

    private List<IEvent> _eventStore = new List<IEvent>();
    //Simulate pushing to DB, here just using in memory list

    public void PublishEvent(IEvent evt)
    {
        _eventStore.Add(evt);
        RaiseEvent?.Invoke(this, evt);
    }

    public void Subscribe(EventHandler<IEvent> handler)
    {
        RaiseEvent += handler;
    }
}

