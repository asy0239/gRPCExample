using Domain.MessageBus.Connection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary
{
    public interface IRabbitMQConfiguration : IConfiguration
    {
        ConnectionFactory GetConnectionFactory();
    }
}
