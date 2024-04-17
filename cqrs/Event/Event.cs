


namespace Event;
public class Event<EventData>(string eventType, EventData eventData) : IEvent
{

    public string Type { get; set; } = eventType;
    public EventData Data { get; set; } = eventData;

    public DateTime EventTime { get; } = DateTime.Now;

    public string GetEventType()
    {
        return Type;
    }
        
}