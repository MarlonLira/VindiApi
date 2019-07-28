using System;
using System.Collections.Generic;
using System.Text;

namespace Vindi
{
    public class MerchantUsers
    {
        public int id { get; set; }
        public string status { get; set; }
        public DateTime? last_sign_in_at { get; set; }
        public User user { get; set; }
        public Role role { get; set; }
    }
}
