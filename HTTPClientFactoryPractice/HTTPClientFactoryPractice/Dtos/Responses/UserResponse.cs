using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientFactoryPractice.Dtos.Responses
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
