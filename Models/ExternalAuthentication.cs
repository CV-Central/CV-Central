using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_Central.Models
{
    public class ExternalAuthentication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Provider { get; set; }
        public string ProviderKey { get; set; }
        public User User { get; set; }
    }
}