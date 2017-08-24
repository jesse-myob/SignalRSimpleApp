using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.DataAccess.Models
{
    public class UserLog
    {
        [Key]
        public int UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
    }
}
