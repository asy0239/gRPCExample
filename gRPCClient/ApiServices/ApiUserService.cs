using gRPCClient.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient.ApiServices
{
    public class ApiUserService : BackgroundService
    {
        private readonly ILogger<ApiUserService> _logger;
        private readonly UserControl _userControl;

        public ApiUserService(ILogger<ApiUserService> logger, UserControl userControl)
        {
            _logger = logger;
            _userControl = userControl;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _userControl.CreateUserAsync();
        }
    }
}
