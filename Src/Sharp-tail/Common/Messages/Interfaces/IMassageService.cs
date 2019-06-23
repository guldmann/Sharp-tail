using System;

namespace Common.Messages.Interfaces
{
    public interface IMassageService
    {
        /// <summary>
        /// Subscribe to a message type
        /// </summary>
        /// <typeparam name="TMessage">Message type </typeparam>
        /// <param name="handlers">Method to handle message</param>
        void Subscribe<TMessage>(Action<TMessage> handlers);

        /// <summary>
        /// UnSubscribe for message or type
        /// </summary>
        /// <typeparam name="TMessage">message type</typeparam>
        /// <param name="handler"></param>
        void Unsubscribe<TMessage>(Action<TMessage> handler);

        /// <summary>
        /// Publish a message of type TMessage to the messageService
        /// </summary>
        /// <typeparam name="TMessage">Message type </typeparam>
        /// <param name="message"> </param>
        void Publish<TMessage>(TMessage message);

        /// <summary>
        /// Publish a message to MessageService
        /// </summary>
        /// <param name="message">Object to pas in massage</param>
        void Publish(object message);
    }
}
