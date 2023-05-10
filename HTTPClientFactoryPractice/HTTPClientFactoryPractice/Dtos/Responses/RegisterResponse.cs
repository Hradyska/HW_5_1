using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientFactoryPractice.Dtos.Responses
{
    public class RegisterResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
