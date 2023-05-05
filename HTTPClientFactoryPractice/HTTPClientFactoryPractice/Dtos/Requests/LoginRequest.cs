using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HTTPClientFactoryPractice.Dtos.Requests
{
    public class LoginRequest
    {
        public FormUrlEncodedContent FormContent { get; set; }
    }
}
