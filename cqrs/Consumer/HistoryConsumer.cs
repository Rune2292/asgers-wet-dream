


using ReadModel;

namespace Consumer;


public class HistoryConsumer{
        
    private HistoryModel _historyModel;

    public HistoryConsumer(HistoryModel historyModel, EventStore eventStore)
    {
        _historyModel = historyModel;
        eventStore.Subscribe(ConsumeEvent);
    }

    
}