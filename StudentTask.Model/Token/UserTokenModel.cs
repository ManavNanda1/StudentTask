using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Model.Token
{
    public class UserTokenModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int UserLoginId { get; set; }
        public int LoginHistoryId { get; set; }
        public string UserName { get; set; }
        public DateTime TokenValidTo { get; set; }
    }
}
