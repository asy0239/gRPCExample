using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistences
{
    public interface IMessageQueue
    {
        Task<string> GetValueAsync(string key);
        Task SetValueAsync(string key, string value);
        Task<bool> RemoveKeyAsync(string key);
        Task PublishMessageAsync(string queueName, string message);
        Task<string> ConsumeMessageAsync(string queueName);
    }
}
