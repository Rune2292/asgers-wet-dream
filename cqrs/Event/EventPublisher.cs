
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Components.Web;

using Cmd;

namespace Event
{

        public class CommandPublisher
        {
            private Dictionary<Type, Delegate> eventHandlers = new Dictionary<Type, Delegate>();
            public event EventHandler<EventArgs>? RaiseEvent;
            //Simulate pushing to DB, here just using in memory list
            private List<EventArgs> _eventStore = new List<EventArgs>();

            public void PublishEvent(CommandEvent e)
            {
                //add validation?
                _eventStore.Add(e);
                OnRaiseEvent(e);
            }
            
            public void OnRaiseEvent(CommandEvent e)
            {
                switch (e.EventType)
                {
                    case Type t when t == typeof(DepositMoney):
                        RaiseEvent += OnDepositHandler;
                        break;
                    case Type t when t == typeof(WithdrawMoney):
                        RaiseEvent += WithdrawMoneyEventHandler;
                        break;
                    default:
                        break;
                }


                if (eventHandlers.ContainsKey(e.GetType()))
                {
                    eventHandlers[e.GetType()].DynamicInvoke(this, e);
                }
            }
        }

}