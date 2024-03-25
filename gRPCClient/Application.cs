using gRPCClient.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient
{
    public class Application
    {
        private readonly ApiUserService _apiUserService;
        public Application(ApiUserService apiService) 
        {
            _apiUserService = apiService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. 사용자 입력, 2. 사용자 가져오기");
                int selectNum = int.Parse(Console.ReadLine());

                if (selectNum == 1)
                {
                    _apiUserService.CreateAsync();
                }
                else if (selectNum == 2)
                {
                    Console.WriteLine("Key 입력 : ");
                    _apiUserService.GetUserAsync(int.Parse(Console.ReadLine()));
                }
            }   
        }
    }
}
