using System.Collections.Generic;

namespace WAVets2Tech_API.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<Response> Responses { get; set; }

        public List<Student> Students { get; set; }

        public List<Employer> Employers { get; set; }
        
        public List<Admin> Admins { get; set; }
    }
}
