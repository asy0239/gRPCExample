using Api.Users;
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
    public class ApiUserService
    {
        private readonly UserControl _userControl;

        public ApiUserService(UserControl userControl)
        {
            _userControl = userControl;
        }

        public async Task CreateAsync()
        {
            await _userControl.CreateUserAsync();
        }

        public async Task GetUserAsync(int key)
        {
            await _userControl.GetUserAsync(key);
        }
    }
}
