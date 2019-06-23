using System;
using System.Collections.Generic;
using Common.Messages.Interfaces;

namespace Common.Messages.Services
{
    public sealed class MessageService : IMassageService
    {
        private static volatile MessageService _instance;
        private static object _syncRoot = new object();
        private Dictionary<Type, List<Object>> _Subscribers = new Dictionary<Type, List<object>>();

        private MessageService() { }

        public static MessageService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new MessageService();
                    }
                }
                return _instance;
            }
        }

        public void Publish<TMessage>(TMessage message)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _Subscribers[typeof(TMessage)];
                foreach (Action<TMessage> handler in handlers)
                {
                    handler.Invoke(message);
                }
            }
        }

        public void Publish(object message)
        {
            var messageType = message.GetType();
            if (_Subscribers.ContainsKey(messageType))
            {
                var handlers = _Subscribers[messageType];
                foreach (var handler in handlers)
                {
                    var actionType = handler.GetType();
                    var invoke = actionType.GetMethod("Invoke", new Type[] { messageType });
                    invoke.Invoke(handler, new Object[] { message });
                }
            }
        }

        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _Subscribers[typeof(TMessage)];
                handlers.Add(handler);
            }
            else
            {
                var handlers = new List<object>();
                handlers.Add(handler);
                _Subscribers[typeof(TMessage)] = handlers;
            }
        }

        public void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handelers = _Subscribers[typeof(TMessage)];
                handelers.Remove(handler);
                if (handelers.Count == 0)
                {
                    _Subscribers.Remove(typeof(TMessage));
                }
            }
        }
    }
}
