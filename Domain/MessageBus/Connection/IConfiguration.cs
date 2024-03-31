using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MessageBus.Connection
{
    public interface IConfiguration
    {
        IAddress Address { get; set; }
    }
}
