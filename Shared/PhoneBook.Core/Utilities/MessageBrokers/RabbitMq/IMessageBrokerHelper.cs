namespace PhoneBook.Core.Utilities.MessageBrokers.RabbitMq
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(string messageText);
    }
}