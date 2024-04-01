using gRPCClient.ApiServices;
using gRPCClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient
{
    public class Application
    {
        //private readonly ApiUserService _apiUserService;
        private readonly UserControl _userControl;
        public Application(UserControl apiService) 
        {
            _userControl = apiService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. 사용자 입력, 2. 사용자 가져오기");
                int selectNum = int.Parse(Console.ReadLine());

                if (selectNum == 1)
                {
                    _userControl.CreateUserAsync();
                }
                else if (selectNum == 2)
                {
                    Console.WriteLine("Key 입력 : ");
                    _userControl.GetUserAsync(int.Parse(Console.ReadLine()));
                }
            }   
        }
    }
}
