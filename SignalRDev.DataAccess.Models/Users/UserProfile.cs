using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.DataAccess.Models.Users
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
