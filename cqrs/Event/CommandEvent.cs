


namespace Event{
    public class CommandEvent : EventArgs
    {
        public Type? EventType { get; set; }
        public object? EventData { get; set; }

        public CommandEvent(Type eventType, object eventData)
        {
            EventType = eventType;
            EventData = eventData;
        }
    }


}